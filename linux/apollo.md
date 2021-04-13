# 拉取apollo脚本

```
$ git clone https://github.com/ctripcorp/apollo.git
$ mysql -uroot -p0 < apollo/scripts/sql/apolloportaldb.sql
$ mysql -uroot -p0 < apollo/scripts/sql/apolloconfigdb.sql
$ update ServerConfig set Value="http://172.17.9.74:8080/eureka/" 
	where `key`="eureka.service.url";
```

# Config Service

```
$ docker pull apolloconfig/apollo-configservice
$ docker run -d \
    --name apollo-configservice \
    --net=host \
    -v /tmp/logs:/opt/logs \
    -e spring_datasource_url="jdbc:mysql://172.17.9.74:3306/ApolloConfigDB?characterEncoding=utf8" \
    -e spring_datasource_username=root \
    -e spring_datasource_password=0 \
	-p 8080:8080 \
	--restart=always \
    apolloconfig/apollo-configservice
```

# Admin Service

```
$ docker pull apolloconfig/apollo-adminservice
$ docker run -d \
    --name apollo-adminservice \
    --net=host \
    -v /tmp/logs:/opt/logs \
    -e spring_datasource_url="jdbc:mysql://172.17.9.74:3306/ApolloConfigDB?characterEncoding=utf8" \
    -e spring_datasource_username=root \
    -e spring_datasource_password=0 \
	-p 8090:8090 \
	--restart=always \
    apolloconfig/apollo-adminservice
```
	
# Portal Server

```
$ docker pull apolloconfig/apollo-portal
$ docker run -d \
    --name apollo-portal \
    --net=host \
    -v /tmp/logs:/opt/logs \
    -e spring_datasource_url="jdbc:mysql://172.17.9.74:3306/ApolloPortalDB?characterEncoding=utf8" \
    -e spring_datasource_username=root \
    -e spring_datasource_password=0 \
    -e APOLLO_PORTAL_ENVS=dev \
	-p 8400:8070 \
	-e DEV_META=http://172.17.9.74:8080 \
	--restart=always \
    apolloconfig/apollo-portal
```

# 开放端口

```
$ firewall-cmd --zone=public --add-port=8400/tcp --permanent
$ firewall-cmd --reload
```