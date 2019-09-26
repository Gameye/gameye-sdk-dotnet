<a name='assembly'></a>
# Gameye.Sdk

## Contents

- [GameyeClient](#T-Gameye-Sdk-GameyeClient 'Gameye.Sdk.GameyeClient')
  - [#ctor(clientConfig)](#M-Gameye-Sdk-GameyeClient-#ctor-Gameye-Sdk-GameyeClientConfig- 'Gameye.Sdk.GameyeClient.#ctor(Gameye.Sdk.GameyeClientConfig)')
  - [LogStore](#P-Gameye-Sdk-GameyeClient-LogStore 'Gameye.Sdk.GameyeClient.LogStore')
  - [SessionStore](#P-Gameye-Sdk-GameyeClient-SessionStore 'Gameye.Sdk.GameyeClient.SessionStore')
  - [StatisticsStore](#P-Gameye-Sdk-GameyeClient-StatisticsStore 'Gameye.Sdk.GameyeClient.StatisticsStore')
  - [CommandStartMatch(matchKey,gameKey,locationKeys,templateKey,config,endCallbackUrl)](#M-Gameye-Sdk-GameyeClient-CommandStartMatch-System-String,System-String,System-String[],System-String,System-Collections-Generic-Dictionary{System-String,System-Object},System-String- 'Gameye.Sdk.GameyeClient.CommandStartMatch(System.String,System.String,System.String[],System.String,System.Collections.Generic.Dictionary{System.String,System.Object},System.String)')
  - [CommandStopMatch(matchKey)](#M-Gameye-Sdk-GameyeClient-CommandStopMatch-System-String- 'Gameye.Sdk.GameyeClient.CommandStopMatch(System.String)')
  - [SubscribeLogEvents(matchKey,onStreamClosed)](#M-Gameye-Sdk-GameyeClient-SubscribeLogEvents-System-String,System-Action- 'Gameye.Sdk.GameyeClient.SubscribeLogEvents(System.String,System.Action)')
  - [SubscribeSessionEvents(onStreamClosed)](#M-Gameye-Sdk-GameyeClient-SubscribeSessionEvents-System-Action- 'Gameye.Sdk.GameyeClient.SubscribeSessionEvents(System.Action)')
  - [SubscribeStatisticsEvents(matchKey,onStreamClosed)](#M-Gameye-Sdk-GameyeClient-SubscribeStatisticsEvents-System-String,System-Action- 'Gameye.Sdk.GameyeClient.SubscribeStatisticsEvents(System.String,System.Action)')
- [GameyeClientConfig](#T-Gameye-Sdk-GameyeClientConfig 'Gameye.Sdk.GameyeClientConfig')
  - [#ctor(endpoint,token)](#M-Gameye-Sdk-GameyeClientConfig-#ctor-System-String,System-String- 'Gameye.Sdk.GameyeClientConfig.#ctor(System.String,System.String)')
- [LogLine](#T-Gameye-Sdk-LogLine 'Gameye.Sdk.LogLine')
  - [LineKey](#P-Gameye-Sdk-LogLine-LineKey 'Gameye.Sdk.LogLine.LineKey')
  - [Payload](#P-Gameye-Sdk-LogLine-Payload 'Gameye.Sdk.LogLine.Payload')
  - [ToString()](#M-Gameye-Sdk-LogLine-ToString 'Gameye.Sdk.LogLine.ToString')
- [LogSelectors](#T-Gameye-Sdk-LogSelectors 'Gameye.Sdk.LogSelectors')
  - [SelectAllLogs(logState)](#M-Gameye-Sdk-LogSelectors-SelectAllLogs-Gameye-Sdk-LogState- 'Gameye.Sdk.LogSelectors.SelectAllLogs(Gameye.Sdk.LogState)')
  - [SelectLogsSince(logState,lineNumber)](#M-Gameye-Sdk-LogSelectors-SelectLogsSince-Gameye-Sdk-LogState,System-Int32- 'Gameye.Sdk.LogSelectors.SelectLogsSince(Gameye.Sdk.LogState,System.Int32)')
- [LogStore](#T-Gameye-Sdk-LogStore 'Gameye.Sdk.LogStore')
  - [OnChange](#P-Gameye-Sdk-LogStore-OnChange 'Gameye.Sdk.LogStore.OnChange')
- [MissingConfigException](#T-Gameye-Sdk-MissingConfigException 'Gameye.Sdk.MissingConfigException')
- [Player](#T-Gameye-Sdk-Player 'Gameye.Sdk.Player')
  - [Connected](#P-Gameye-Sdk-Player-Connected 'Gameye.Sdk.Player.Connected')
  - [Name](#P-Gameye-Sdk-Player-Name 'Gameye.Sdk.Player.Name')
  - [PlayerKey](#P-Gameye-Sdk-Player-PlayerKey 'Gameye.Sdk.Player.PlayerKey')
  - [Statistic](#P-Gameye-Sdk-Player-Statistic 'Gameye.Sdk.Player.Statistic')
  - [Uid](#P-Gameye-Sdk-Player-Uid 'Gameye.Sdk.Player.Uid')
- [Session](#T-Gameye-Sdk-Session 'Gameye.Sdk.Session')
  - [Created](#P-Gameye-Sdk-Session-Created 'Gameye.Sdk.Session.Created')
  - [Host](#P-Gameye-Sdk-Session-Host 'Gameye.Sdk.Session.Host')
  - [Id](#P-Gameye-Sdk-Session-Id 'Gameye.Sdk.Session.Id')
  - [Image](#P-Gameye-Sdk-Session-Image 'Gameye.Sdk.Session.Image')
  - [Location](#P-Gameye-Sdk-Session-Location 'Gameye.Sdk.Session.Location')
  - [Port](#P-Gameye-Sdk-Session-Port 'Gameye.Sdk.Session.Port')
- [SessionSelectors](#T-Gameye-Sdk-SessionSelectors 'Gameye.Sdk.SessionSelectors')
  - [SelectSession(sessionState,sessionId)](#M-Gameye-Sdk-SessionSelectors-SelectSession-Gameye-Sdk-SessionState,System-String- 'Gameye.Sdk.SessionSelectors.SelectSession(Gameye.Sdk.SessionState,System.String)')
  - [SelectSessionList(sessionState)](#M-Gameye-Sdk-SessionSelectors-SelectSessionList-Gameye-Sdk-SessionState- 'Gameye.Sdk.SessionSelectors.SelectSessionList(Gameye.Sdk.SessionState)')
  - [SelectSessionListForGame(sessionState,gameKey)](#M-Gameye-Sdk-SessionSelectors-SelectSessionListForGame-Gameye-Sdk-SessionState,System-String- 'Gameye.Sdk.SessionSelectors.SelectSessionListForGame(Gameye.Sdk.SessionState,System.String)')
- [SessionStore](#T-Gameye-Sdk-SessionStore 'Gameye.Sdk.SessionStore')
  - [OnChange](#P-Gameye-Sdk-SessionStore-OnChange 'Gameye.Sdk.SessionStore.OnChange')
- [StatisticsSelectors](#T-Gameye-Sdk-StatisticsSelectors 'Gameye.Sdk.StatisticsSelectors')
  - [SelectPlayer(statisticsState,playerKey)](#M-Gameye-Sdk-StatisticsSelectors-SelectPlayer-Gameye-Sdk-StatisticsState,System-String- 'Gameye.Sdk.StatisticsSelectors.SelectPlayer(Gameye.Sdk.StatisticsState,System.String)')
  - [SelectPlayerList(statisticsState)](#M-Gameye-Sdk-StatisticsSelectors-SelectPlayerList-Gameye-Sdk-StatisticsState- 'Gameye.Sdk.StatisticsSelectors.SelectPlayerList(Gameye.Sdk.StatisticsState)')
  - [SelectPlayerListForTeam(statisticsState,teamKey)](#M-Gameye-Sdk-StatisticsSelectors-SelectPlayerListForTeam-Gameye-Sdk-StatisticsState,System-String- 'Gameye.Sdk.StatisticsSelectors.SelectPlayerListForTeam(Gameye.Sdk.StatisticsState,System.String)')
  - [SelectRawStatistics(statisticsState)](#M-Gameye-Sdk-StatisticsSelectors-SelectRawStatistics-Gameye-Sdk-StatisticsState- 'Gameye.Sdk.StatisticsSelectors.SelectRawStatistics(Gameye.Sdk.StatisticsState)')
  - [SelectRounds(statisticsState)](#M-Gameye-Sdk-StatisticsSelectors-SelectRounds-Gameye-Sdk-StatisticsState- 'Gameye.Sdk.StatisticsSelectors.SelectRounds(Gameye.Sdk.StatisticsState)')
  - [SelectTeam(statisticsState,teamKey)](#M-Gameye-Sdk-StatisticsSelectors-SelectTeam-Gameye-Sdk-StatisticsState,System-String- 'Gameye.Sdk.StatisticsSelectors.SelectTeam(Gameye.Sdk.StatisticsState,System.String)')
  - [SelectTeamList(statisticsState)](#M-Gameye-Sdk-StatisticsSelectors-SelectTeamList-Gameye-Sdk-StatisticsState- 'Gameye.Sdk.StatisticsSelectors.SelectTeamList(Gameye.Sdk.StatisticsState)')
- [StatisticsStore](#T-Gameye-Sdk-StatisticsStore 'Gameye.Sdk.StatisticsStore')
  - [OnChange](#P-Gameye-Sdk-StatisticsStore-OnChange 'Gameye.Sdk.StatisticsStore.OnChange')
- [Team](#T-Gameye-Sdk-Team 'Gameye.Sdk.Team')
  - [Name](#P-Gameye-Sdk-Team-Name 'Gameye.Sdk.Team.Name')
  - [Player](#P-Gameye-Sdk-Team-Player 'Gameye.Sdk.Team.Player')
  - [Statistic](#P-Gameye-Sdk-Team-Statistic 'Gameye.Sdk.Team.Statistic')
  - [TeamKey](#P-Gameye-Sdk-Team-TeamKey 'Gameye.Sdk.Team.TeamKey')

<a name='T-Gameye-Sdk-GameyeClient'></a>
## GameyeClient `type`

##### Namespace

Gameye.Sdk

<a name='M-Gameye-Sdk-GameyeClient-#ctor-Gameye-Sdk-GameyeClientConfig-'></a>
### #ctor(clientConfig) `constructor`

##### Summary

Create a new client

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| clientConfig | [Gameye.Sdk.GameyeClientConfig](#T-Gameye-Sdk-GameyeClientConfig 'Gameye.Sdk.GameyeClientConfig') |  |

<a name='P-Gameye-Sdk-GameyeClient-LogStore'></a>
### LogStore `property`

##### Summary

LogStore. Used to add callbacks for events.

<a name='P-Gameye-Sdk-GameyeClient-SessionStore'></a>
### SessionStore `property`

##### Summary

SessionStore. Used to add callbacks for events.

<a name='P-Gameye-Sdk-GameyeClient-StatisticsStore'></a>
### StatisticsStore `property`

##### Summary

StatisticsStore. Used to add callbacks for events.

<a name='M-Gameye-Sdk-GameyeClient-CommandStartMatch-System-String,System-String,System-String[],System-String,System-Collections-Generic-Dictionary{System-String,System-Object},System-String-'></a>
### CommandStartMatch(matchKey,gameKey,locationKeys,templateKey,config,endCallbackUrl) `method`

##### Summary

Start a match

##### Returns

An awaitable task that finishes when the command is executed

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| matchKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Unique identifier for the match. Also known as SessionId |
| gameKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Identifier for the game (eg: csgo) |
| locationKeys | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | Array of locations |
| templateKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Game template |
| config | [System.Collections.Generic.Dictionary{System.String,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.String,System.Object}') | Game config dictionary |
| endCallbackUrl | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional) The url callback when the game is finished |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [Gameye.Messaging.Client.CommandException](#T-Gameye-Messaging-Client-CommandException 'Gameye.Messaging.Client.CommandException') | Thrown if the command fails |

<a name='M-Gameye-Sdk-GameyeClient-CommandStopMatch-System-String-'></a>
### CommandStopMatch(matchKey) `method`

##### Summary

Stop a match

##### Returns

An awaitable task that finishes when the command is executed

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| matchKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Unique identifier for the match. Also known as SessionId |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [Gameye.Messaging.Client.CommandException](#T-Gameye-Messaging-Client-CommandException 'Gameye.Messaging.Client.CommandException') | Thrown if the command fails |

<a name='M-Gameye-Sdk-GameyeClient-SubscribeLogEvents-System-String,System-Action-'></a>
### SubscribeLogEvents(matchKey,onStreamClosed) `method`

##### Summary

Subscribe to all log events for a given match

##### Returns

An awaitable task that finishes when the stream is opened

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| matchKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Unique identifier for the match. Also known as SessionId |
| onStreamClosed | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') | (Optional) callback when the stream is closed. This occurs when a match ends |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [Gameye.Messaging.Client.CommandException](#T-Gameye-Messaging-Client-CommandException 'Gameye.Messaging.Client.CommandException') | Thrown if the event stream subscription fails |

<a name='M-Gameye-Sdk-GameyeClient-SubscribeSessionEvents-System-Action-'></a>
### SubscribeSessionEvents(onStreamClosed) `method`

##### Summary

Subscribe to all session events

##### Returns

An awaitable task that finishes when the stream is opened

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| onStreamClosed | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') | (Optional) callback when the stream is closed. This occurs when a match ends |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [Gameye.Messaging.Client.CommandException](#T-Gameye-Messaging-Client-CommandException 'Gameye.Messaging.Client.CommandException') | Thrown if the event stream subscription fails |

<a name='M-Gameye-Sdk-GameyeClient-SubscribeStatisticsEvents-System-String,System-Action-'></a>
### SubscribeStatisticsEvents(matchKey,onStreamClosed) `method`

##### Summary

Subscribe to all statistic events for a given match

##### Returns

An awaitable task that finishes when the stream is opened

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| matchKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Unique identifier for the match. Also known as SessionId |
| onStreamClosed | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') | (Optional) callback when the stream is closed. This occurs when a match ends |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [Gameye.Messaging.Client.CommandException](#T-Gameye-Messaging-Client-CommandException 'Gameye.Messaging.Client.CommandException') | Thrown if the event stream subscription fails |

<a name='T-Gameye-Sdk-GameyeClientConfig'></a>
## GameyeClientConfig `type`

##### Namespace

Gameye.Sdk

##### Summary

Client config for the Gameye SDK

<a name='M-Gameye-Sdk-GameyeClientConfig-#ctor-System-String,System-String-'></a>
### #ctor(endpoint,token) `constructor`

##### Summary

Create a new client config

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| endpoint | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The endpoint provided to you by Gameye |
| token | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The API token provided to you by Gameye |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [Gameye.Sdk.MissingConfigException](#T-Gameye-Sdk-MissingConfigException 'Gameye.Sdk.MissingConfigException') | When a required element is missing from the config |

<a name='T-Gameye-Sdk-LogLine'></a>
## LogLine `type`

##### Namespace

Gameye.Sdk

##### Summary

Log Line Object

<a name='P-Gameye-Sdk-LogLine-LineKey'></a>
### LineKey `property`

##### Summary

The line number

<a name='P-Gameye-Sdk-LogLine-Payload'></a>
### Payload `property`

##### Summary

The log message

<a name='M-Gameye-Sdk-LogLine-ToString'></a>
### ToString() `method`

##### Summary

Print this LogLine object in the format $"{LineKey}: {Payload}"

##### Returns



##### Parameters

This method has no parameters.

<a name='T-Gameye-Sdk-LogSelectors'></a>
## LogSelectors `type`

##### Namespace

Gameye.Sdk

<a name='M-Gameye-Sdk-LogSelectors-SelectAllLogs-Gameye-Sdk-LogState-'></a>
### SelectAllLogs(logState) `method`

##### Summary

Select all the logs in the store. Use this as an extension method on LogState

##### Returns

An ImmutableArray of LogLines

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logState | [Gameye.Sdk.LogState](#T-Gameye-Sdk-LogState 'Gameye.Sdk.LogState') |  |

<a name='M-Gameye-Sdk-LogSelectors-SelectLogsSince-Gameye-Sdk-LogState,System-Int32-'></a>
### SelectLogsSince(logState,lineNumber) `method`

##### Summary

Select all the logs since a given line number. Use this as an extension method on LogState

##### Returns

An ImmutableArray of LogLines

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logState | [Gameye.Sdk.LogState](#T-Gameye-Sdk-LogState 'Gameye.Sdk.LogState') |  |
| lineNumber | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The line number after which to select logs |

<a name='T-Gameye-Sdk-LogStore'></a>
## LogStore `type`

##### Namespace

Gameye.Sdk

<a name='P-Gameye-Sdk-LogStore-OnChange'></a>
### OnChange `property`

##### Summary

Triggered when a Log subsciption receieves new events

<a name='T-Gameye-Sdk-MissingConfigException'></a>
## MissingConfigException `type`

##### Namespace

Gameye.Sdk

##### Summary

Exception representing a missing field in the GameyeClientConfig

<a name='T-Gameye-Sdk-Player'></a>
## Player `type`

##### Namespace

Gameye.Sdk

##### Summary

Player object for Statistics purposes

<a name='P-Gameye-Sdk-Player-Connected'></a>
### Connected `property`

##### Summary

Is the player currently connected

<a name='P-Gameye-Sdk-Player-Name'></a>
### Name `property`

##### Summary

Player name

<a name='P-Gameye-Sdk-Player-PlayerKey'></a>
### PlayerKey `property`

##### Summary

Player key

<a name='P-Gameye-Sdk-Player-Statistic'></a>
### Statistic `property`

##### Summary

Player statistics

<a name='P-Gameye-Sdk-Player-Uid'></a>
### Uid `property`

##### Summary

Unique identifier of a player

<a name='T-Gameye-Sdk-Session'></a>
## Session `type`

##### Namespace

Gameye.Sdk

##### Summary

Session object

<a name='P-Gameye-Sdk-Session-Created'></a>
### Created `property`

##### Summary

Unix epoch time of when the session was created

<a name='P-Gameye-Sdk-Session-Host'></a>
### Host `property`

##### Summary

IP address of the Host of the session

<a name='P-Gameye-Sdk-Session-Id'></a>
### Id `property`

##### Summary

The unique identifier of a session. Also known as the Match Key.

<a name='P-Gameye-Sdk-Session-Image'></a>
### Image `property`

##### Summary

Game image used to launch the session. Also known as the Game Key

<a name='P-Gameye-Sdk-Session-Location'></a>
### Location `property`

##### Summary

Hosted location of the session

<a name='P-Gameye-Sdk-Session-Port'></a>
### Port `property`

##### Summary

Dictionary of Ports available for this session

<a name='T-Gameye-Sdk-SessionSelectors'></a>
## SessionSelectors `type`

##### Namespace

Gameye.Sdk

<a name='M-Gameye-Sdk-SessionSelectors-SelectSession-Gameye-Sdk-SessionState,System-String-'></a>
### SelectSession(sessionState,sessionId) `method`

##### Summary

Select a single session with the given id. Use this as an extension method on SessionState

##### Returns

A Session object or null if not found

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sessionState | [Gameye.Sdk.SessionState](#T-Gameye-Sdk-SessionState 'Gameye.Sdk.SessionState') |  |
| sessionId | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Gameye-Sdk-SessionSelectors-SelectSessionList-Gameye-Sdk-SessionState-'></a>
### SelectSessionList(sessionState) `method`

##### Summary

Select all the active sessions. Use this as an extension method on SessionState

##### Returns

An ImmutableArray of sessions

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sessionState | [Gameye.Sdk.SessionState](#T-Gameye-Sdk-SessionState 'Gameye.Sdk.SessionState') |  |

<a name='M-Gameye-Sdk-SessionSelectors-SelectSessionListForGame-Gameye-Sdk-SessionState,System-String-'></a>
### SelectSessionListForGame(sessionState,gameKey) `method`

##### Summary

Select sessions with the given game key. Use this as an extension method on SessionState

##### Returns

An ImmutableArray of sessions

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sessionState | [Gameye.Sdk.SessionState](#T-Gameye-Sdk-SessionState 'Gameye.Sdk.SessionState') |  |
| gameKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Gameye-Sdk-SessionStore'></a>
## SessionStore `type`

##### Namespace

Gameye.Sdk

<a name='P-Gameye-Sdk-SessionStore-OnChange'></a>
### OnChange `property`

##### Summary

Triggered when a session subsciption receieves new events

<a name='T-Gameye-Sdk-StatisticsSelectors'></a>
## StatisticsSelectors `type`

##### Namespace

Gameye.Sdk

<a name='M-Gameye-Sdk-StatisticsSelectors-SelectPlayer-Gameye-Sdk-StatisticsState,System-String-'></a>
### SelectPlayer(statisticsState,playerKey) `method`

##### Summary

Select a single player by key. Use this as an extension method on StatisticsState

##### Returns

A player object or null if not found

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| statisticsState | [Gameye.Sdk.StatisticsState](#T-Gameye-Sdk-StatisticsState 'Gameye.Sdk.StatisticsState') |  |
| playerKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Key of the player |

<a name='M-Gameye-Sdk-StatisticsSelectors-SelectPlayerList-Gameye-Sdk-StatisticsState-'></a>
### SelectPlayerList(statisticsState) `method`

##### Summary

Select the list of all players. Use this as an extension method on StatisticsState

##### Returns

An ImmutableArray of Players

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| statisticsState | [Gameye.Sdk.StatisticsState](#T-Gameye-Sdk-StatisticsState 'Gameye.Sdk.StatisticsState') |  |

<a name='M-Gameye-Sdk-StatisticsSelectors-SelectPlayerListForTeam-Gameye-Sdk-StatisticsState,System-String-'></a>
### SelectPlayerListForTeam(statisticsState,teamKey) `method`

##### Summary

Select the list of players on a given team. Use this as an extension method on StatisticsState

##### Returns

An ImmutableArray of Players

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| statisticsState | [Gameye.Sdk.StatisticsState](#T-Gameye-Sdk-StatisticsState 'Gameye.Sdk.StatisticsState') |  |
| teamKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Key of the team |

<a name='M-Gameye-Sdk-StatisticsSelectors-SelectRawStatistics-Gameye-Sdk-StatisticsState-'></a>
### SelectRawStatistics(statisticsState) `method`

##### Summary

Select the raw statistics Json. Use this as an extension method on StatisticsState

##### Returns

A Newtonsoft JObject containing the current statistics snapshot

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| statisticsState | [Gameye.Sdk.StatisticsState](#T-Gameye-Sdk-StatisticsState 'Gameye.Sdk.StatisticsState') |  |

<a name='M-Gameye-Sdk-StatisticsSelectors-SelectRounds-Gameye-Sdk-StatisticsState-'></a>
### SelectRounds(statisticsState) `method`

##### Summary

Select the number of started rounds. Use this as an extension method on StatisticsState

##### Returns

A long representing the number of started rounds

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| statisticsState | [Gameye.Sdk.StatisticsState](#T-Gameye-Sdk-StatisticsState 'Gameye.Sdk.StatisticsState') |  |

<a name='M-Gameye-Sdk-StatisticsSelectors-SelectTeam-Gameye-Sdk-StatisticsState,System-String-'></a>
### SelectTeam(statisticsState,teamKey) `method`

##### Summary

Select a single team by key. Use this as an extension method on StatisticsState

##### Returns

A Team object or null if not found

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| statisticsState | [Gameye.Sdk.StatisticsState](#T-Gameye-Sdk-StatisticsState 'Gameye.Sdk.StatisticsState') |  |
| teamKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Key of the team |

<a name='M-Gameye-Sdk-StatisticsSelectors-SelectTeamList-Gameye-Sdk-StatisticsState-'></a>
### SelectTeamList(statisticsState) `method`

##### Summary

Select the list of all teams. Use this as an extension method on StatisticsState

##### Returns

An ImmutableArray of Teams

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| statisticsState | [Gameye.Sdk.StatisticsState](#T-Gameye-Sdk-StatisticsState 'Gameye.Sdk.StatisticsState') |  |

<a name='T-Gameye-Sdk-StatisticsStore'></a>
## StatisticsStore `type`

##### Namespace

Gameye.Sdk

<a name='P-Gameye-Sdk-StatisticsStore-OnChange'></a>
### OnChange `property`

##### Summary

Triggered when a statistics subsciption receieves new events

<a name='T-Gameye-Sdk-Team'></a>
## Team `type`

##### Namespace

Gameye.Sdk

##### Summary

Team object for Statistics purposes

<a name='P-Gameye-Sdk-Team-Name'></a>
### Name `property`

##### Summary

Team name

<a name='P-Gameye-Sdk-Team-Player'></a>
### Player `property`

##### Summary

Dictionary of players and whether they are currently on this team

<a name='P-Gameye-Sdk-Team-Statistic'></a>
### Statistic `property`

##### Summary

Team statistics

<a name='P-Gameye-Sdk-Team-TeamKey'></a>
### TeamKey `property`

##### Summary

Team key
