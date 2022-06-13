# Portable Operating System Interface ( POSIX )

[https://www.baeldung.com/linux/posix](https://www.baeldung.com/linux/posix)

## Overview

Đó là tiêu chuẩn được IEEE chỉ định để duy trì khả năng tương thích giữa các hệ điều hành. Do đó, bất kỳ phần mềm tiêu chuẩn nào tuân theo POSIX đều tương thích với các hệ điều hành tuân theo POSIX.

Vì lý do đó, hầu hết các công cụ chúng tôi sử dụng trên hệ điều hành giống như Linux và Unix đều hoạt động gần như giống nhau. Ví dụ: nếu chúng ta sử dụng lệnh ps , nó sẽ hoạt động giống nhau trong OpenBSD, Debian và macOS.

## Các tiêu chuẩn do POSIX xác định

Trong phần này, chúng ta sẽ xem xét một số tiêu chuẩn POSIX cần thiết. Ngoài ra, chúng tôi có thể sử dụng [Vấn đề Thông số Cơ sở Nhóm Mở](https://pubs.opengroup.org/onlinepubs/9699919799/nframe.html) làm tài liệu tham khảo chuyên sâu.

### API C

POSIX xác định các tiêu chuẩn của nó theo ngôn ngữ C. Do đó, các chương trình có thể di động đến các hệ điều hành khác ở cấp mã nguồn . Tuy nhiên, chúng tôi cũng có thể triển khai nó bằng bất kỳ ngôn ngữ chuẩn hóa nào.

API POSIX C bổ sung nhiều chức năng hơn trên Tiêu chuẩn ANSI C cho một số khía cạnh:

- Hoạt động tệp
- Các quy trình, luồng, bộ nhớ dùng chung và các tham số lập lịch
- Kết nối mạng
- Quản lý bộ nhớ
- Biểu thức chính quy

### Khái niệm chung

Ngoài C API, POSIX cũng bổ sung các quy tắc để viết chương trình, như an toàn cho việc khởi tạo các loại con trỏ và thực thi đồng thời. Nó cũng thực thi các quy tắc để đồng bộ hóa bộ nhớ, chẳng hạn như hạn chế sửa đổi bộ nhớ khi nó đã được sử dụng. Ngoài ra, nó cũng nêu rõ các cơ chế bảo mật để bảo vệ thư mục và truy cập tệp.

### Định dạng tệp

POSIX xác định các quy tắc để định dạng chuỗi mà chúng tôi sử dụng trong tệp, đầu ra tiêu chuẩn, lỗi tiêu chuẩn và đầu vào tiêu chuẩn. Ví dụ, hãy xem xét mô tả cho một chuỗi đầu ra:

> ```"<format>", [ <arg1>, ..., <argN> ]```

Định dạng có thể chứa các ký tự thông thường, [ký tự thoát](https://pubs.opengroup.org/onlinepubs/9699919799/basedefs/V1_chap05.html#tagtcjh_2) và [các thông số kỹ thuật chuyển đổi](https://www.gnu.org/software/libc/manual/html_node/Table-of-Input-Conversions.html). Các thông số kỹ thuật chuyển đổi cho biết định dạng đầu ra của các đối số được cung cấp và được bắt đầu bằng ký hiệu phần trăm theo sau là loại đối số.

Ví dụ, giả sử chúng ta muốn xuất một chuỗi có chứa ngày hôm nay. Chúng tôi sẽ sử dụng tiện ích printf vì nó tuân theo tiêu chuẩn định dạng tệp POSIX:

>```
>$ printf "Today's Date: %d %s, %d" 18 September 2021
>Today's Date: 18 September, 2021
>```

Định dạng chỉ định ba đặc điểm chuyển đổi: % d , % s và % d . Tiện  ích printf xử lý các đặc tả chuyển đổi này và thay thế chúng bằng các đối số.
