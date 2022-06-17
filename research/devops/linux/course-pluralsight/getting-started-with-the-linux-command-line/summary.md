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
