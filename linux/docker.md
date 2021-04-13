# 更新

```
$ yum update
```

# 卸载docker

```
$ yum remove docker docker-common docker-selinux docker-engine
```

# 安装依赖

```
$ yum install -y yum-utils device-mapper-persistent-data lvm2
```

# 设置镜像地址

```
$ yum-config-manager --add-repo https://download.docker.com/linux/centos/docker-ce.repo
```

# 查看docker

```
$ yum list docker-ce --showduplicates | sort -r
```


# 安装docker

```
$ yum install docker-ce
```

# 启动docker

```
$ systemctl start docker
$ systemctl enable docker
```

# 验证docker

```
$ docker version
```

# 拉取镜像

```
$ docker pull *
```

# 启动容器

```
$ docker run * *
```

# 删除容器

```
$ docker rm -f *
```

# 删除镜像

```
$ docker rmi *
```

# docker-compose

```
$ curl -L https://github.com/docker/compose/releases/download/1.28.6/docker-compose-`uname -s`-`uname -m` -o /usr/local/bin/docker-compose
$ chmod +x /usr/local/bin/docker-compose
$ docker-compose --version
```