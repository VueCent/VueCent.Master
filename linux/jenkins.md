# 拉取jenkins镜像

```
$ docker pull jenkins/jenkins
```

# 检查jenkins镜像

```
$ docker images
```

# 运行jenkins

```
$ mkdir -p /var/jenkins_mount
$ chmod 777 /var/jenkins_mount
$ docker run -d -p 8700:8080 -p 50000:50000 \
	-v /var/jenkins_mount:/var/jenkins_home \
	-v /etc/localtime:/etc/localtime \
	--name jenkins \
	--restart=always \
	jenkins/jenkins
```

# 开放端口

```
$ firewall-cmd --zone=public --add-port=8700/tcp --permanent
$ firewall-cmd --reload
```

# 密码

```
$ docker logs ***
$ vim /var/jenkins_home/secrets/initialAdminPassword
```