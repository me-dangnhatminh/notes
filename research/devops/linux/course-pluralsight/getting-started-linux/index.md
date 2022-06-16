
# 4 Configuring the Linux Environment

```bash
df -ht ext4

# Hiển thị tất cả các thiết bị khối hiện được gắn trên hệ thống.
# -h : định dạng size (GB)
# -t : type, in is ext4
```

```bash
lsblk | grep sd

# Xem tất cả các thiết bị khối được gắn vào hệ thống vật lý
```

```bash
sudo mount /dev/sdb2 /media/newplace

# dev/sdb2 là một phân vùng
# /media/newplace/ là thư mục muốn sử dụng phân vùng ấy
```

```bash
dmesg
dmesg | grep wl
dmesg | wc

# Hiển thị các thông báo liên quan đến bộ đệm vòng kernel
```

```bash
sudo lshw | less

# Hiển thị thông tin phần cứng bao gồm, core, cpu, ram, ...
# Phải apt install lshw (vì lshw không có sẵn)
```

```bash
yum install lshw
```

## Summary

```bash
less /etc/default/grub
systemctl enable multi-user.target
localectl set-locale LANG=en_CA.utf8
export myVar
df -ht ext4
lsblk | grep sd
dmesg
```
