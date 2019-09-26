<a name='assembly'></a>
# Gameye.Sdk

## Contents

- [GameyeClient](#T-Gameye-Sdk-GameyeClient 'Gameye.Sdk.GameyeClient')
  - [#ctor(clientConfig)](#M-Gameye-Sdk-GameyeClient-#ctor-Gameye-Sdk-GameyeClientConfig- 'Gameye.Sdk.GameyeClient.#ctor(Gameye.Sdk.GameyeClientConfig)')
  - [CommandStartMatch(matchKey,gameKey,locationKeys,templateKey,config,endCallbackUrl)](#M-Gameye-Sdk-GameyeClient-CommandStartMatch-System-String,System-String,System-String[],System-String,System-Collections-Generic-Dictionary{System-String,System-Object},System-String- 'Gameye.Sdk.GameyeClient.CommandStartMatch(System.String,System.String,System.String[],System.String,System.Collections.Generic.Dictionary{System.String,System.Object},System.String)')
  - [CommandStopMatch(matchKey)](#M-Gameye-Sdk-GameyeClient-CommandStopMatch-System-String- 'Gameye.Sdk.GameyeClient.CommandStopMatch(System.String)')
  - [SubscribeLogEvents(matchKey,onStreamClosed)](#M-Gameye-Sdk-GameyeClient-SubscribeLogEvents-System-String,System-Action- 'Gameye.Sdk.GameyeClient.SubscribeLogEvents(System.String,System.Action)')
  - [SubscribeSessionEvents(onStreamClosed)](#M-Gameye-Sdk-GameyeClient-SubscribeSessionEvents-System-Action- 'Gameye.Sdk.GameyeClient.SubscribeSessionEvents(System.Action)')
  - [SubscribeStatisticsEvents(matchKey,onStreamClosed)](#M-Gameye-Sdk-GameyeClient-SubscribeStatisticsEvents-System-String,System-Action- 'Gameye.Sdk.GameyeClient.SubscribeStatisticsEvents(System.String,System.Action)')
- [GameyeClientConfig](#T-Gameye-Sdk-GameyeClientConfig 'Gameye.Sdk.GameyeClientConfig')
  - [#ctor(endpoint,token)](#M-Gameye-Sdk-GameyeClientConfig-#ctor-System-String,System-String- 'Gameye.Sdk.GameyeClientConfig.#ctor(System.String,System.String)')
- [LogSelectors](#T-Gameye-Sdk-LogSelectors 'Gameye.Sdk.LogSelectors')
  - [SelectAllLogs(logState)](#M-Gameye-Sdk-LogSelectors-SelectAllLogs-Gameye-Sdk-LogState- 'Gameye.Sdk.LogSelectors.SelectAllLogs(Gameye.Sdk.LogState)')
  - [SelectLogsSince(logState)](#M-Gameye-Sdk-LogSelectors-SelectLogsSince-Gameye-Sdk-LogState,System-Int32- 'Gameye.Sdk.LogSelectors.SelectLogsSince(Gameye.Sdk.LogState,System.Int32)')
- [LogStore](#T-Gameye-Sdk-LogStore 'Gameye.Sdk.LogStore')
  - [OnChange](#P-Gameye-Sdk-LogStore-OnChange 'Gameye.Sdk.LogStore.OnChange')
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

<a name='M-Gameye-Sdk-GameyeClient-CommandStartMatch-System-String,System-String,System-String[],System-String,System-Collections-Generic-Dictionary{System-String,System-Object},System-String-'></a>
### CommandStartMatch(matchKey,gameKey,locationKeys,templateKey,config,endCallbackUrl) `method`

##### Summary

Start a match

##### Returns

An awaitable task that finishes when the command is executed

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| matchKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| gameKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| locationKeys | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') |  |
| templateKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| config | [System.Collections.Generic.Dictionary{System.String,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.String,System.Object}') |  |
| endCallbackUrl | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

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
| matchKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

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
| matchKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| onStreamClosed | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') |  |

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
| onStreamClosed | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') |  |

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
| matchKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| onStreamClosed | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') |  |

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

<a name='T-Gameye-Sdk-LogSelectors'></a>
## LogSelectors `type`

##### Namespace

Gameye.Sdk

<a name='M-Gameye-Sdk-LogSelectors-SelectAllLogs-Gameye-Sdk-LogState-'></a>
### SelectAllLogs(logState) `method`

##### Summary

Select all the logs in the store

##### Returns

An ImmutableArray of LogLines

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logState | [Gameye.Sdk.LogState](#T-Gameye-Sdk-LogState 'Gameye.Sdk.LogState') |  |

<a name='M-Gameye-Sdk-LogSelectors-SelectLogsSince-Gameye-Sdk-LogState,System-Int32-'></a>
### SelectLogsSince(logState) `method`

##### Summary

Select all the logs since a given line number

##### Returns

An ImmutableArray of LogLines

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logState | [Gameye.Sdk.LogState](#T-Gameye-Sdk-LogState 'Gameye.Sdk.LogState') |  |

<a name='T-Gameye-Sdk-LogStore'></a>
## LogStore `type`

##### Namespace

Gameye.Sdk

<a name='P-Gameye-Sdk-LogStore-OnChange'></a>
### OnChange `property`

##### Summary

Triggered when a Log subsciption receieves new events

<a name='T-Gameye-Sdk-SessionSelectors'></a>
## SessionSelectors `type`

##### Namespace

Gameye.Sdk

<a name='M-Gameye-Sdk-SessionSelectors-SelectSession-Gameye-Sdk-SessionState,System-String-'></a>
### SelectSession(sessionState,sessionId) `method`

##### Summary

Select a single session with the given id

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

Select all the active sessions

##### Returns

An ImmutableArray of sessions

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sessionState | [Gameye.Sdk.SessionState](#T-Gameye-Sdk-SessionState 'Gameye.Sdk.SessionState') |  |

<a name='M-Gameye-Sdk-SessionSelectors-SelectSessionListForGame-Gameye-Sdk-SessionState,System-String-'></a>
### SelectSessionListForGame(sessionState,gameKey) `method`

##### Summary

Select sessions with the given game key

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

Select a single player by key

##### Returns

A player object or null if not found

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| statisticsState | [Gameye.Sdk.StatisticsState](#T-Gameye-Sdk-StatisticsState 'Gameye.Sdk.StatisticsState') |  |
| playerKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Gameye-Sdk-StatisticsSelectors-SelectPlayerList-Gameye-Sdk-StatisticsState-'></a>
### SelectPlayerList(statisticsState) `method`

##### Summary

Select the list of all players

##### Returns

An ImmutableArray of Players

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| statisticsState | [Gameye.Sdk.StatisticsState](#T-Gameye-Sdk-StatisticsState 'Gameye.Sdk.StatisticsState') |  |

<a name='M-Gameye-Sdk-StatisticsSelectors-SelectPlayerListForTeam-Gameye-Sdk-StatisticsState,System-String-'></a>
### SelectPlayerListForTeam(statisticsState,teamKey) `method`

##### Summary

Select the list of players on a given team

##### Returns

An ImmutableArray of Players

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| statisticsState | [Gameye.Sdk.StatisticsState](#T-Gameye-Sdk-StatisticsState 'Gameye.Sdk.StatisticsState') |  |
| teamKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Gameye-Sdk-StatisticsSelectors-SelectRawStatistics-Gameye-Sdk-StatisticsState-'></a>
### SelectRawStatistics(statisticsState) `method`

##### Summary

Select the raw statistics Json

##### Returns

A Newtonsoft JObject containing the current statistics snapshot

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| statisticsState | [Gameye.Sdk.StatisticsState](#T-Gameye-Sdk-StatisticsState 'Gameye.Sdk.StatisticsState') |  |

<a name='M-Gameye-Sdk-StatisticsSelectors-SelectRounds-Gameye-Sdk-StatisticsState-'></a>
### SelectRounds(statisticsState) `method`

##### Summary

Select the number of started rounds

##### Returns

A long representing the number of started rounds

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| statisticsState | [Gameye.Sdk.StatisticsState](#T-Gameye-Sdk-StatisticsState 'Gameye.Sdk.StatisticsState') |  |

<a name='M-Gameye-Sdk-StatisticsSelectors-SelectTeam-Gameye-Sdk-StatisticsState,System-String-'></a>
### SelectTeam(statisticsState,teamKey) `method`

##### Summary

Select a single team by key

##### Returns

A Team object or null if not found

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| statisticsState | [Gameye.Sdk.StatisticsState](#T-Gameye-Sdk-StatisticsState 'Gameye.Sdk.StatisticsState') |  |
| teamKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Gameye-Sdk-StatisticsSelectors-SelectTeamList-Gameye-Sdk-StatisticsState-'></a>
### SelectTeamList(statisticsState) `method`

##### Summary

Select the list of all teams

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
