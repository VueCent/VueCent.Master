# 拉取exceptionless镜像

```
$ docker pull exceptionless/exceptionless
```

# 检查exceptionless镜像

```
$ docker images
```

# 运行exceptionless

```
$ docker run --name exceptionless -d -p 8200:80 --restart=always exceptionless/exceptionless
```

# 开放端口

```
$ firewall-cmd --zone=public --add-port=8200/tcp --permanent
$ firewall-cmd --reload
```