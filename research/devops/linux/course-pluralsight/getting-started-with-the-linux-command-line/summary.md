# **2 Working with linux command line basics**

## **2.1 Using linux help resources**

Thêm tiền tố sudo: vì nó cho phép người dùng đặc quyền chạy các chương trình đơn lẻ với toàn quyền admin mà không cần phải chạy toàn bộ shell với tư cách là root, một thứ mà về lâu dài rủi ro bảo mật đáng kể.

```bash
ls -lht
# h: định dạng size ở đây là K(kilobyte)
# t: sắp xếp time giảm dần

tar xzf filename.tar.gz
```

```bash
info
info wget examples simple
```

```bash
whereis ls
which ls

# Tìm vị trí của tệp nhị phân
# whereis sẽ cho thông tin chi tiết hơn which
```

```bash
type wget
type ls
# Trả về kiểu của lệnh nhị phân
```

## **2.2 The linux terminal**

Bất kể khi nào ta mở một cửa sổ terminal từ desktop linux, một shell mới sẽ được tạo cho bạn bằng cách sử dụng các cài đặt mặc định trong tệp ẩn đặc biệt trong thư mục chính (/home/dangnhatminh) **.bashrc**

# **3 Navigating the Linux File System**

## **3.2 Searching the Linux File System**

```bash
locate adduser
# Tìm các file có tên adduser
```

```bash
sudo updatedb
# List các tệp vừa được thêm gần đây
```

```bash
cat /etc/group | grep ubuntu >> newfile
# cat sẽ đọc dữ liệu từ /etc/group rồi truyền dữ liệu qua grep thông qua pipe và grep sẽ lọc các dòng có từ ubuntu cuối cùng ">>" là để lưu dữ liệu lọc được ra một file
# 2 mũi tên ">>" sẽ nối, một mũi tên sẽ ghi đè
```

```bash
head /etc/group
tail /etc/group
# head in ra số dòng đầu tiên (mặc định 10 dòng)
# tail in ra số dòng cuối (mặc định 10 dòng)
# tail -f rất hữu ích khi đọc log
```

```bash
cut -d: -f3 /etc/group
cut -d ":" -f 3 /etc/group

# Điều này có nghĩa là gì
# Nếu mình có một file với dữ liệu như bên dưới
# 1|dangnhatminh|20
# 2|nguyen dao nguyen trinh|20
# 3|tram|22
# 4|chi|21
cut -d "|" -f 2 filename
# dữ liệu trả về sẽ là các dòng có dữ liệu là những cái tên(dangnhatminh, ...trinh, tram)
# giải thích: mỗi dòng nó sẽ tách ra các phần theo dấu "|" và mỗi phần sẽ được đánh cột và dùng -f "2" ở đây 2 là cột thứ 2
```

```bash
sort -n
# dùng để sắp xếp
# vd cách dùng cut: cut -d "|" -f 1 filename | sort -n
# -n là tăng dần, -nr là giảm dần
```

```bash
wc filename
# wc: write count, đếm số dòng, từ trong một file
```

### **Standard Streams**

| Name | Designation | Numeric Code |
| --- | --- | --- |
| Standard Input | stdin | 0 |
| Standard Output | stdout | 1 |
| Standard Error | stderr | 2 |

```bash
wget abc.comm 2> errlog.txt
# wget abc.comm là input vì abc.comm k có nên wget sẽ trả về dữ liệu lỗi chuyển hướng nó vao file errlog.txt

wget abc.comm 12> ouptfile.txt
# lỗi hay chuẩn đều sẽ vào file ouptfile.txt
```

## **3.3 Working with Archives**

### Creating Data Archives

tar:  tape archive, công cụ để lưu trữ và nén file phổ biến của unix

tar opstion

- c – create an archive file.
- x – extract an archive file.
- v – show the progress of the archive file.
- f – filename of the archive file.
- t – viewing the content of the archive file.
- j – filter archive through bzip2.
- z – filter archive through gzip.
- r – append or update files or directories to the existing archive files.
- W – Verify an archive file.
wildcards – Specify patterns in UNIX tar command.

```bash
gzip
```

```bash
zip -r filename.zip *
# Nén thành một file zip
# * là tất cả dữ liệu trong thư mục hiện tại
# -r là nó sẽ đệ quy vào thư mục

unzip
# để giải nén file zip
```

### Linux Kernel Modules and Peripherals

```bash
lsusb
lspci
lshw #hw: hardware
```

```bash
ls /lib/modules/
# Các modules được lưu trong thư mục này

uname -r
# -r: phiên bản của kernel
# -n: thông tin của hostname
# -v: phiên bản phát hành

# cách viết này hơi lạ
ls /lib/modules/'uname -r'

lsmod | grep sound
# lsmod liệt kê các Loadable kernel module đã tải
# grep sound lọc ra các module cho sound

modprobe soundcore
# tải một Loadable kernel module
```

# **4 Linux Network Connectivity**

```bash
ip route show

sudo dhclient
# dùng để xem liệu máy chủ DHCP trên mạng có thể cung cấp cho bạn địa chỉ ip không
# DHCB: dynamic host configuration protocol

ip address
# xem địa chỉ của riêng mình

route
# tương lự lệnh ip ( có thể gặp ở một số os cũ, không có sẵn trong ubuntu 20)

# install net-tools để sử dụng ifconfig và netstat
ifconfig
# tương tự route ( có thể gặp ở một số os cũ, không có sẵn trong ubuntu 20)

netstat -i
netstat -l

ss -i
# ss có sẵn trong linux
# hiển thị chi tiết thông tin mạng

host facebook.com
# lệnh này sẽ has dns thành address ipv4, ipv6, ...

ping facebook.com
# kiểm tra xem domain có hoạt động không
```

Bạn quản lý cài đặt DNS của mình từ tệp: **/etc/resolv.conf**

```bash
systemd-resolve --status
# cho ta thấy mọi thứ đang được cấu hình ntn

cat /etc/hosts
```

## **4.3 Remote connections and ssh**

### Installingg OpenSSH

Server

- apt install openssh-server

Client

- apt install openssh-client

```bash
cd /etc/ssh
# ssh server và client để được cấu hình trong /etc/ssh

ssh ubuntu@10.0.21.131
ssh -p 22 ubuntu@10.0.21.131
ssh -i /home/myusername/mykeyfile.pem ubuntu@10.0.21.131

scp fromfile.txt ubuntu@10.0.21.131:/home/ubuntu/to
# Lệnh này sẽ truyền dữ liệu từ máy của mình tới máy remote
# lấy fromfile.txt bỏ vào /home/ubuntu/to của remote
```

# *5 Linux Scripting*

Trong file myscript.sh

```bash
#! /bin/bash
declare -i number1
declare -i number2
declare -i total
echo "What's your favorite number?"
    read number1
echo "What number do you really hate? "
    read number2
total=$number1+$number2
    echo "Aha! They equal " $total
exit 0
```

!# /bin/bash là để nói với linux là chạy lệnh /bin/bash

read là dữ liệu người dùng nhập vào

echo là xuất dữ liệu ra terminal

```bash
# Trước khi chạy được file ở trên ta phải cấp quyền cho nó
chmod +x myscript.sh

# Để run file ta chỉ việc nhập filename.sh
```

### Working with loops and flow control

```bash
#! /bin/bash
for i in {0..10..2}
    do
        echo "We've been through this $i times already"
    done
# {0..10..2} điều này có nghĩa là mảng sẽ có giá trị từ 0 tới 10 và với gia số là 2 {0,2,4...}
```

```bash
#! /bin/bash

# Có thể loop qua các file
for file in file1 file2
    do
        echo "Hello" > $file
    done
# nó sẽ duyệt qua các file và ghi "Hello" và từng file
```

```bash
#! /bin/bash
echo "What is your favorite color? "
    read text1
echo "What is your best friend is favorite color? "
    read text2
if test $text1 != text2; then
    echo "I guess opposites attract."
else
    echo "You two do think alike!
fi
exit 0
```

Tương tự đối với while, do while, switch-case, ...
