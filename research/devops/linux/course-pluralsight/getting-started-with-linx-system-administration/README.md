Course Overview

Users and Groups

Security

- Permissions
- Software Update
- Network port audits
- Encryption

Docket Containers

- bootstrap-it.com/linux-admin

# **2 Optimizing your linux system**

## **2.2 Monitoring system resources**

### **System Performance Metrics**

```bash
cd /proc
# Thư mục lưu đữ liệu về tài nguyên của hệ thống bao gồm cả tài nguyên bị tiêu hao

top
# top: lệnh cung cấp một màn hình tự động cập nhật đầy đủ dữ liệu

free -h
# free: lênh xem nhanh bộ nhớ đã dùng và còn trống
# -h là định dạng gigabyte

df
# dùng để xem trạng thái của tất cả các thiết bị này hiện đang được gắn vào hệ thống của bạn
df -t ext4
# -t là để lọc các vùng có định dạng ext4
```

```bash
sudo apt install iftop
# iftop package giám sát hệ thống mạng (băng thông, độ trễ, ...)
sudo iftop -i eth0
# để lấy thông tin eth0 dùng lênh ip addr
```

## **2.3 Managing system processes - part one**

Monitor process event data ( Giám sát dữ liệu quy trình)

Terminal Processes

Enable/disable processes

```bash
ps
# Hiện thị các process đang hoạt động (bash, ps, ...)
ps aux
# aux sẽ hiện ra thông tin về mọi process hoạt động trên toàn bộ hệ thống của bạn

journalctl --since "10 minutes ago"

cd /var/log
# Thư mục lưu nhật ký được quản lý bởi syslogd
```

## **2.3 Manging system process - part two**

```bash
sudo dmesg
# dmesg là để quản lý các message đến từ bộ đệm vòng kernal
# the kernal ring buffer là nơi lưu trữ các message từ quá trình khởi động gần đây nhất

yes > /dev/null &
# bất kỳ đầu ra nào vào /dev/null sẽ bị xóa ngay lập tức
# dấu "&" sẽ làm cho quá trình chạy ở tiến trình nền

kill 1234
# kill dùng để kill một process, trong đó 1234 là PID của process (dùng ps để lấy thông tin tiến trình)
killall yes
# Sự khác biệt giữa kill và killall là gì: kill sẽ chỉ hoạt động trên tiến trình sử dụng PID cụ thể, killall sẽ kill tất cả trường hợp có trên hệ thống

sudo systemctl status apache2
# các quy trình được kiểm soát bới systemctl

sudo systemctl enable apache2
# enable là tự khởi động mỗi khi khởi động máy tính
# disable là tắt tự khởi động
sudo systemctl start apache2
```

## **2.4 Managing Process Priority**

```bash
nice -19 yes > /etc/null &
# nice dùng để set sự ưu tiên cho tiến trình
# khi call lệnh top, sẽ có một row là NI, cột này hiển thị sự ưu tiên

renice 15 -p 1211
# 15 là số ưu tiên
# 1211 là PID
```

# **3 Working With Usres and Group in Linux**

- Account data
- Access control
- Access activity data
- Managing accounts
- Managing groups

## **3.2 Understand linux user**

### Admin Powers: Best practices (Quyền hạn quản trị)

- Avoid using the root account (Tránh sử dụng tài khoản root)
- Creating unique accounts for each user (Tạo tài khoản duy nhất cho mỗi người dùng)
- Assign only necessay authority to each user (Chỉ chỉ định quyền cần thiết cho mỗi người dùng)
- Use admin power only via sudo (Chỉ sử dụng quyền admin thông qua sudo)

```bash
sudo cat /etc/shadow
# thư mục chứa mật khẩu

sudo cat /etc/passwd
# dangnhatminh:x:1000:1000:dangnhatminh,,,:/home/dangnhatminh:/bin/bash
# 1 - dangnhatminh - cho biết username
# 2 - x - cho biết sự tồn tại của pass trong tệp shadow
# 3,4 - 1000:1000 - là id user và id group

sudo cat /etc/group
# liệt kê các group

id dangnhatminh
# hiển thị thông tin của người dùng dangnhatminh

who
# cho biết người dùng hiện tại đang đăng nhập

w
# cho ta biết ai đăng nhập và cả việc họ đang làm

last
# nhập ký đăng nhập từ đầu tháng
```

### **Adminstrating Users and Groups**

```bash
sudo useradd -m username
# -m : tạo một thư mục mới trong home tree (/home/username)

sudo adduser username
# adduser sẽ hỏi thêm các thông tin (pass, fullname, phone) trong quá trình tạo

cd /etc/skel
# Thư mục xương, nghĩa là bất kỳ nếu tạo một người dùng mới nó nó sẽ có cá thư mục tương tự /etc/skel -> /home/user sẽ giống /etc/skel khi mới tạo

sudo passwd username
# dùng để thiết lập passwd cho người dùng

sudo groupadd groupname
# tạo một group 

sudo chown :groupname /var/secret
# dùng để set group cho thư mục secret

sudo usermod -a -G groupname username
# addgroup cho người dùng
# nghĩa là người dùng sẽ có quyền đối với group này

sudo chmod g+wer /var/sercet

groups username
# xem người dùng thuộc group nào

deluser username
deluser --remove-home newuser
# xóa một người dùng, --remove-home sẽ xóa luôn thư mục được tạo trong /home

visudo
```

# **4 Securing your linux server**

## **4.1 Module Introduction**

- Permissions
- Software patches
- Managing network port
- Data encryption

### **Applying object Permissions**

```bash
su username
# chuyển đổi người dùng

ls -dl
# -d sẽ liệt kê các thuộc tính
```

### **Extending Object Usability**

```bash
sudo chomod +t foldername|filename
# +t 

sudo ln -s /home/dangnhatminh/scripts/myscript.sh /var/secret
# Tạo một liên kết
```

### **Hardening Your Server**

- Reducing vulnerability (giảm tính sẽ bị tồn thương)
- Patching systems (Hệ thống vá lỗi)
- Understanding network ports

[https://wiki.debian.org/Team/Dpkg](https://wiki.debian.org/Team/Dpkg)

```bash
nmap -v -sT localhost
# phải install package nmap
# Quét bằng giao thức tcp để tìm các port đang mở
nmap -v -sT google.com
```

### **Data Encryption**

- Why encrypt
- Disk encryption
- SSL/TSL encryption
- Email encryption

# **5 Working with Docker and Linux Container**
