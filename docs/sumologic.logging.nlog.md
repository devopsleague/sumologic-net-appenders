# SumoLogic.Logging.NLog

## Description

SumoLogic provides an interface between NLog and remote service Logging. You can logging its application as the usual way.
Once you have downloaded the NuGet package, you can watch the example project for configuration details.

## Minimum requirements

- .NET 4.5 or later or .NET Standard 1.5

## Targets

- SumoLogicTarget: It instantly pushes the log message to SumoLogic.
- BufferedSumoLogicTarget: It makes a log messages queue. It pushes the queue if the maximum quantity of messages was reached or if the maximum flush interval has passed.

## Configuration

- The configuration is in NLog.config. There are two target, BufferedSumoLogicTarget and SumoLogicTarget.
- We recommend to use the BufferedSumoLogicTarget because SumoLogicTarget might make the application runs slower.
- The output url is which you get from SumoLogic http collector.

## Properties

### SumoLogicTarget

| Argument                  | Description                                                                           | Default value         |
|---------------------------|---------------------------------------------------------------------------------------|----------------------:|
| Url                       | The http collector URL from SumoLogic.                                                | __mandatory__         |
| SourceName                | The named used for messages sent to SumoLogic.                                        | `Nlog-SumoObject`     |
| SourceCategory            | The category used for messages sent to SumoLogic.                                     | `null`                |
| SourceHost                | The host used for messages sent to SumoLogic.                                         | `null`                |
| ConnectionTimeout         | The connection timeout in milliseconds.                                               | `60000`               |

### BufferedSumoLogicTarget

| Argument                  | Description                                                                           | Default value             |
|---------------------------|---------------------------------------------------------------------------------------|--------------------------:|
| Url                       | The http collector URL from SumoLogic.                                                | __mandatory__             |
| SourceName                | The named used for messages sent to SumoLogic.                                        | `Nlog-SumoObject-Buffered`|
| SourceCategory            | The category used for messages sent to SumoLogic.                                     | `null`                    |
| SourceHost                | The host used for messages sent to SumoLogic.                                         | `null`                    |
| ConnectionTimeout         | The connection timeout in milliseconds.                                               | `60000`                   |
| FlushingAccuracy          | How often the messages queue is checked for messages to send, in milliseconds.        | `250`                     |
| MaxFlushInterval          | The maximum interval between flushes, in milliseconds.                                | `10000`                   |
| MessagePerRequest         | How many messages need to be in the queue before flushing.                            | `100`                     |
| MaxQueueSizeBytes         | The messages queue capacity in bytes. Messages will be dropped when it is exceeded.   | `1000000`                 |