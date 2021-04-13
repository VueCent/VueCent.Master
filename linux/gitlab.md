# 拉取

```
$ docker pull gitlab/gitlab-ce
```

# 检查

```
$ docker images
```

# 容器

```
$ mkdir -p /docker/gitlab/config
$ mkdir -p /docker/gitlab/logs
$ mkdir -p /docker/gitlab/data
```

# 运行

```
$ docker run -p 8100:80 -p 443:443 -p 22:22 \
 -v /docker/gitlab/config:/etc/gitlab \
 -v /docker/gitlab/logs:/var/log/gitlab \
 -v /docker/gitlab/data:/var/opt/gitlab \
 --name=gitlab --privileged=true \
 --restart=always gitlab/gitlab-ce
```

#配置

```
$ docker exec -it gitlab /bin/bash
$ cd opt/gitlab/embedded/service/gitlab-rails/config
$ vim gitlab.yml
$ gitlab-ctl restart
```

# 开放端口

```
$ firewall-cmd --zone=public --add-port=8100/tcp --permanent
$ firewall-cmd --reload
```