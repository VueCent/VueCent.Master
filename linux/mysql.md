# 拉取

```
$ docker pull mysql
```

# 检查

```
$ docker images
```

# 运行

```
$ docker run -p 3306:3306 --name mysql -e MYSQL_ROOT_PASSWORD=0 -d --restart=always mysql
* –name：容器名，此处命名为mysql
* -e：配置信息，此处配置mysql的root用户的登陆密码
* -p：端口映射，此处映射 主机3306端口 到 容器的3306端口
* -d：后台运行容器，保证在退出终端后容器继续运行
```

# 开放端口

```
$ firewall-cmd --zone=public --add-port=3306/tcp --permanent
$ firewall-cmd --reload
```

# 连接

```
$ docker exec -it mysql bash
$ mysql -uroot -p0
```

# 赋权

```
ALTER USER 'root'@'%' IDENTIFIED WITH mysql_native_password BY '0';
ALTER USER 'root'@'localhost' IDENTIFIED WITH mysql_native_password BY '0';
```

# 退出

```
$ exit
```