# 拉取vsftpd镜像

```
$ yum install vsftpd -y
```

# 检查vsftpd镜像

```
$ rpm -q vsftpd
$ vsftpd -v
$ whereis vsftpd
```

# 运行vsftpd镜像

```
$ systemctl start vsftpd.service
$ setsebool -P ftpd_full_access on
```

# 开机启动vsftpd

```
$ systemctl enable vsftpd.service
```

# 白名单

```
$ firewall-cmd --permanent --zone=public --add-service=ftp
$ firewall-cmd --reload
```

# 配置vsftpd

```
$ vim /etc/vsftpd/vsftpd.conf

anon_upload_enable=YES
anon_mkdir_write_enable=YES
anon_other_write_enable=YES
anon_world_readable_only=YES
```

# 权限

```
$ chmod 777 -R /var/ftp/pub
```

# 重启vsftpd

```
$ systemctl restart vsftpd.service
```