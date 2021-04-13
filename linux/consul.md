# 拉取 consul 镜像

```
$ docker pull consul
```

# 检查 consul 镜像

```
$ docker images
```

# 运行 consul

```
$ docker run --name consul -d -p 8500:8500 --restart=always consul
```

# 开放端口

```
$ firewall-cmd --zone=public --add-port=8500/tcp --permanent
$ firewall-cmd --reload
```