# 拉取

```
$ yum -y install epel-release
$ yum -y install supervisor
```

# 开机启动

```
$ systemctl enable supervisord
```

# 运行

```
$ supervisord -c /etc/supervisord.conf
$ supervisorctl -c /etc/supervisord.conf
```

#查看服务状态

```
$ supervisorctl status
```

# 启动所有

```
$ supervisorctl start all
```

# 重启所有

```
$ supervisorctl restart all
```

# 停止所有

```
$ supervisorctl stop all
```

# 停止

```
$ supervisorctl shutdown
```

# 配置

```
$ cd /etc/supervisord.d
$ touch DotNetCore.ini
-----------------------------------------------------------------------------------------------
[program:Simple]
#运行程序的命令
command=dotnet Simple.dll --urls="http://*:8888"
#命令执行的目录
directory=/var/ftp/pub/wwwroot
#进程环境变量
environment=ASPNETCORE_ENVIRONMENT=Production
#进程执行的用户身份
user=root
#进程停止信号,可以为TERM, HUP, INT, QUIT, KILL, USR1, or USR2等信号默认为TERM 。当用设定的信号去干掉进程,退出码会被认为是expected,非必须设置
stopsignal=INT
#如果是true的话,子进程将在supervisord启动后被自动启动,默认就是true,非必须设置
autostart=true
#这个是设置子进程挂掉后自动重启的情况,有三个选项,false,unexpected和true。如果为false的时候,无论什么情况下,都不会被重新启动,
#如果为unexpected,只有当进程的退出码不在下面的exitcodes里面定义的退出码的时候,才会被自动重启。当为true的时候,只要子进程挂掉,将会被无条件的重启
autorestart=true
#这个选项是子进程启动多少秒之后,此时状态如果是running,则我们认为启动成功了,默认值为1 。非必须设置
startsecs=1
#错误日志文件
stderr_logfile=/var/log/Simple.err.log
#输出日志文件
stdout_logfile=/var/log/Simple.out.log
-----------------------------------------------------------------------------------------------
```

# 开放端口

```
$ firewall-cmd --zone=public --add-port=8888/tcp --permanent
$ firewall-cmd --reload
```
