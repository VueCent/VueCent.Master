# 配置

```
$ cd /etc/yum.repos.d/
$ touch kubernetes.repo
$ vim /etc/yum.repos.d/kubernetes.repo

-------------------------------------------------------------------------
[kubernetes]
name=Kubernetes Repo
baseurl=https://mirrors.aliyun.com/kubernetes/yum/repos/kubernetes-el7-x86_64/
gpgcheck=1
gpgkey=https://mirrors.aliyun.com/kubernetes/yum/doc/rpm-package-key.gpg
enabled=1
-------------------------------------------------------------------------
```

# 安装etcd+kubernetes

```
$ yum -y install etcd kubernetes-master
```

# 配置etcd

```
$ vim /etc/etcd/etcd.conf

-------------------------------------------------------------------------
ETCD_NAME=etcd3
ETCD_DATA_DIR="/var/lib/etcd/etcd3"
ETCD_LISTEN_PEER_URLS="http://172.17.9.73:2380"
ETCD_LISTEN_CLIENT_URLS="http://172.17.9.73:2379,http://172.17.9.73:2379"
ETCD_INITIAL_ADVERTISE_PEER_URLS="http://172.17.9.73:2380"
ETCD_INITIAL_CLUSTER="etcd3=http://172.17.9.73:2380"
ETCD_INITIAL_CLUSTER_STATE="new"
ETCD_INITIAL_CLUSTER_TOKEN="etcd-test"
ETCD_ADVERTISE_CLIENT_URLS="http://172.17.9.73:2379
-------------------------------------------------------------------------
```

# 启动etcd

```
$ systemctl start etcd
$ systemctl enable etcd
```

# 检查etcd

```
$ etcdctl cluster-health
$ etcdctl member list
```

# 配置kubernetes

```
$ vim /etc/kubernetes/config


-------------------------------------------------------------------------
KUBE_MASTER="--master=http://172.17.9.73:8300"
-------------------------------------------------------------------------

$ vim /etc/kubernetes/apiserver 
-------------------------------------------------------------------------
KUBE_API_ADDRESS="--address=172.17.9.73"
KUBE_API_PORT="--port=8300"
KUBELET_PORT="--kubelet-port=10250"
KUBE_ETCD_SERVERS="--etcd-servers=http://172.17.9.73:2379"
KUBE_SERVICE_ADDRESSES="--service-cluster-ip-range=172.17.9.73/16"
-------------------------------------------------------------------------
```

# 添加网络

```
$ etcdctl set /k8s/network/config '{"Network": "172.17.9.73/16"}'
$ etcdctl get /k8s/network/config
```

# 启动

```
$ systemctl start kube-apiserver
$ systemctl start kube-controller-manager
$ systemctl start kube-scheduler

$ systemctl enable kube-apiserver
$ systemctl enable kube-controller-manager
$ systemctl enable kube-scheduler
```

# 开放端口

```
$ firewall-cmd --state
$ firewall-cmd --zone=public --add-port=8300/tcp --permanent
$ firewall-cmd --reload
```

# 查看

```
$ kubectl --version
$ kubectl cluster-info
```