﻿/**
 *    _____ _____ _____ _____    __    _____ _____ _____ _____
 *   |   __|  |  |     |     |  |  |  |     |   __|     |     |
 *   |__   |  |  | | | |  |  |  |  |__|  |  |  |  |-   -|   --|
 *   |_____|_____|_|_|_|_____|  |_____|_____|_____|_____|_____|
 *
 *                UNICORNS AT WARP SPEED SINCE 2010
 *
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
using Microsoft.Extensions.Logging;
using System;

namespace SumoLogic.Logging.AspNetCore
{
    /// <summary>
    /// Sumo Logic Logger implementation
    /// </summary>
    public class Logger : ILogger
    {
        private readonly LoggerProvider provider;

        private readonly string categoryName;

        public Logger(LoggerProvider provider, string categoryName)
        {
            this.provider = provider;
            this.categoryName = categoryName;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            if (!provider.LoggerOptions.EnableScopes)
            {
                return null;
            }

            return provider.BeginScope(state);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= provider.LoggerOptions.MinLogLevel && logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var line = $"{formatter(state, exception)}";
            provider.WriteLine(line, exception, categoryName, logLevel);
        }
    }
}
