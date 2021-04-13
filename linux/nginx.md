# 拉取nginx镜像

```
$ docker pull nginx
$ yum install -y nginx
```

# 检查nginx镜像

```
$ docker images
```

# 运行nginx

```
$ docker run --name nginx -d -p 80:80 --restart=always nginx

```

# 开放端口

```
$ firewall-cmd --zone=public --add-port=80/tcp --permanent
$ firewall-cmd --reload
```

# 配置

```
$ mkdir -p /var/log/nginx
$ mkdir -p /etc/nginx
$ mkdir -p /usr/share/nginx/html
$ docker cp b735b19d7a8c:/etc/nginx ./conf
$ docker cp b735b19d7a8c:/usr/share/nginx/html ./html
$ docker rm -f nginx
$ docker run -d --name nginx -p 80:80 -p 443:443 \
	-v /usr/local/server/nginx/conf:/etc/nginx \
	-v /usr/local/server/nginx/html:/usr/share/nginx/html \
	--restart=always \
	nginx
```