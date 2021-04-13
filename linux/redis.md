# 拉取

```
$ docker pull redis
```

# 检查

```
$ docker images
```

# 运行

```
$ docker run -itd --name redis -p 6379:6379 --restart=always redis
* -p 6379:6379：映射容器服务的 6379 端口到宿主机的 6379 端口。
```

# 开放端口

```
$ firewall-cmd --zone=public --add-port=6379/tcp --permanent
$ firewall-cmd --reload
```

# 连接

```
$ docker exec -it redis /bin/bash
```

# 退出

```
$ exit
```