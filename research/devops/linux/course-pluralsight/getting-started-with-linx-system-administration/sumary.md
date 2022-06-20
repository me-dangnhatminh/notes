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
