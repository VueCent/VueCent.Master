# base

```
$ docker pull apache/skywalking-base
```

# server

```
$ docker pull apache/skywalking-oap-server:8.4.0-es7
$ docker run --name skywalking-oap -d -p 11800:11800 -p 12800:12800 \
  -e SW_STORAGE=h2 \
  --restart=always \
  apache/skywalking-oap-server:8.4.0-es7
```
	
# ui

```
$ docker pull apache/skywalking-ui
$ docker run --name skywalking-ui -d -p 8600:8080 \
  --link skywalking-oap:skywalking-oap \
  -e SW_OAP_ADDRESS=skywalking-oap:12800 \
  --restart=always \
  apache/skywalking-ui
```

# 开放端口

```
$ firewall-cmd --zone=public --add-port=8600/tcp --permanent
$ firewall-cmd --reload
```