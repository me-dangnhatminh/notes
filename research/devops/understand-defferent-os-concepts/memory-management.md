# Memory Management

References documents

[https://www.tutorialspoint.com/operating_system/os_memory_management.htm](https://www.tutorialspoint.com/operating_system/os_memory_management.htm)

Quản lý bộ nhớ là chức năng của một hệ điều hành xử lý hoặc quản lý bộ nhớ chính và di chuyển các quá trình qua lại giữa bộ nhớ chính và đĩa trong khi thực hiện. Quản lý bộ nhớ theo dõi từng vị trí bộ nhớ, bất kể nó được phân bổ cho một số quy trình hoặc nó là miễn phí. Nó kiểm tra xem có bao nhiêu bộ nhớ được phân bổ cho các quy trình. Nó quyết định quá trình nào sẽ nhận được bộ nhớ vào thời gian nào. Nó theo dõi bất cứ khi nào một số bộ nhớ được giải phóng hoặc không được phân bổ và tương ứng, nó cập nhật trạng thái.

## Process Address Space

| SN | Memory Address | Description |
| --- | --- | --- |
| 1 | Symbolic addresses ( Địa chỉ tượng trưng ) | Các địa chỉ được sử dụng trong mã nguồn. Tên biến, hằng số và nhãn lệnh là các phần tử cơ bản của không gian địa chỉ tượng trưng.
| 2 | Relative addresses ( Địa chỉ tương đối ) | Tại thời điểm biên dịch, một trình biên dịch chuyển đổi các địa chỉ tượng trưng thành địa chỉ tương đối. |
| 3 | Physical addresses ( Địa chỉ vật lý ) | Bộ nạp tạo ra các địa chỉ này tại thời điểm một chương trình được tải vào bộ nhớ chính. |

Địa chỉ ảo và địa chỉ vật lý giống nhau trong các lược đồ ràng buộc địa chỉ compile-time và load-time. Địa chỉ ảo và địa chỉ vật lý khác nhau trong lược đồ ràng buộc địa chỉ excution-time.

Tập hợp tất cả các địa chỉ logic được tạo ra bởi một chương trình được gọi là logical address space ( không gian địa chỉ logic ). Tập hợp tất cả các địa chỉ vật lý tương ứng với các địa chỉ logic này được gọi là physical address space ( không gian địa chỉ vật lý ).

Ánh xạ thời gian chạy từ địa chỉ ảo sang địa chỉ vật lý được thực hiện bởi đơn vị quản lý bộ nhớ (MMU) là một thiết bị phần cứng. MMU sử dụng cơ chế sau để chuyển đổi địa chỉ ảo thành địa chỉ thực.

- Giá trị trong thanh ghi cơ sở được thêm vào mọi địa chỉ được tạo bởi một quy trình người dùng, được coi là bù vào thời điểm nó được gửi đến bộ nhớ. Ví dụ: nếu giá trị thanh ghi cơ sở là 10000, thì người dùng cố gắng sử dụng vị trí địa chỉ 100 sẽ được phân bổ lại một cách tự động đến vị trí 10100.

- Chương trình người dùng xử lý các địa chỉ ảo; nó không bao giờ nhìn thấy các địa chỉ vật lý thực.

## Static vs Dynamic Loading

Sự lựa chọn giữa Tải tĩnh hoặc Tải động sẽ được thực hiện tại thời điểm chương trình máy tính đang được phát triển. Nếu bạn phải tải chương trình của mình một cách tĩnh, thì tại thời điểm biên dịch, các chương trình hoàn chỉnh sẽ được biên dịch và liên kết mà không để lại bất kỳ sự phụ thuộc vào chương trình hoặc mô-đun bên ngoài nào. Trình liên kết kết hợp chương trình đối tượng với các mô-đun đối tượng cần thiết khác thành một chương trình tuyệt đối, chương trình này cũng bao gồm các địa chỉ logic.

Nếu bạn đang viết một chương trình được tải động, thì trình biên dịch của bạn sẽ biên dịch chương trình và đối với tất cả các mô-đun mà bạn muốn đưa vào động, chỉ các tham chiếu sẽ được cung cấp và phần còn lại của công việc sẽ được thực hiện tại thời điểm thực thi.

Tại thời điểm tải, với tải tĩnh , chương trình (và dữ liệu) tuyệt đối được tải vào bộ nhớ để bắt đầu thực thi.

Nếu bạn đang sử dụng tính năng tải động, các quy trình động của thư viện được lưu trữ trên đĩa ở dạng có thể định vị lại và chỉ được tải vào bộ nhớ khi chúng được chương trình cần đến.

## Static vs Dynamic Linking

Như đã giải thích ở trên, khi liên kết tĩnh được sử dụng, trình liên kết kết hợp tất cả các mô-đun khác mà một chương trình cần thiết thành một chương trình thực thi duy nhất để tránh bất kỳ sự phụ thuộc nào vào thời gian chạy.

Khi liên kết động được sử dụng, không bắt buộc phải liên kết mô-đun hoặc thư viện thực tế với chương trình, thay vào đó, tham chiếu đến mô-đun động được cung cấp tại thời điểm biên dịch và liên kết. Thư viện liên kết động (DLL) trong Windows và Đối tượng được chia sẻ trong Unix là những ví dụ điển hình về thư viện động.

