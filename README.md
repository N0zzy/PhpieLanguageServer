#### UDP
#### Ip ```127.0.0.1```
#### Port ```9999```

Request: 

```method: file``` open, read and analyze php file
```json
{"method":"file",  "message":null, "file":"/path/file.php"}
```

```method: code``` read and analyze php code
```json
{"method":"code", "message":"php code", "file":"/path/file.php"}
```

```method: connect```
```json
{"method":"connect", "message":null, "file":null}
```

```method: shutdown```
```json
{"method":"shutdown", "message":null, "file":null}
```

```method: hover```
```json
{"method":"hover", "message":null, "file":"/path/file.php", "position":"1-1"}
```

Response:

```method: ????????```
```json
{"method":null, "error":true}
```

```method: connect```
```json
{"method":"connect", "error":false}
```

```method: shutdown```
```json
{"method":"shutdown", "error":false}
```

```method: code```
```json
{"method":"code", "error":false, "message":"text analysis", "file":"/path/file.php", "line":1, "start":"1-1", "end":"1-2"}
```

```method: file```
```json
{"method":"file", "error":false, "message":"text analysis", "file":"/path/file.php", "line":1, "start":"1-1", "end":"1-2"}
```

```method: hover```
```json
{"method":"hover", "error":false, "message":"text analysis", "file":"/path/file.php"}
```