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

## Swapping

Hoán đổi là một cơ chế trong đó một quá trình có thể được hoán đổi tạm thời khỏi bộ nhớ chính (hoặc di chuyển) sang bộ nhớ phụ (đĩa) và làm cho bộ nhớ đó khả dụng cho các quá trình khác. Vào một thời điểm sau, hệ thống sẽ hoán đổi quá trình từ bộ nhớ phụ sang bộ nhớ chính.

Mặc dù hiệu suất thường bị ảnh hưởng bởi quá trình hoán đổi nhưng nó giúp chạy song song nhiều quá trình lớn và lớn và đó là lý do Swapping còn được gọi là một kỹ thuật nén bộ nhớ.

![process swapping](../_src/images/memory-management/process_swapping.jpg)

Tổng thời gian thực hiện bởi quá trình hoán đổi bao gồm thời gian cần thiết để di chuyển toàn bộ quá trình sang đĩa phụ và sau đó sao chép quá trình trở lại bộ nhớ, cũng như thời gian quá trình lấy lại bộ nhớ chính.

Chúng ta hãy giả sử rằng quy trình của người dùng có kích thước 2048KB và trên đĩa cứng tiêu chuẩn nơi quá trình hoán đổi sẽ diễn ra có tốc độ truyền dữ liệu khoảng 1 MB mỗi giây. Quá trình chuyển 1000K thực tế đến hoặc từ bộ nhớ sẽ mất.

```code
2048KB / 1024KB per second
= 2 seconds
= 2000 milliseconds
```

Bây giờ, nếu tính đến thời gian trong và ngoài, thì sẽ mất 4000 mili giây hoàn thành cộng với các chi phí khác trong đó quá trình cạnh tranh để lấy lại bộ nhớ chính.

## Memory Allocation

Bộ nhớ chính thường có hai phân vùng

- Low Memory: Hệ điều hành nằm trong bộ nhớ này.

- High Memory: Các quy trình của người dùng được lưu giữ trong bộ nhớ cao.

| SN | Memory Allocation | Description |
| --- | --- | --- |
| 1 | Single-partition allocation | Trong kiểu phân bổ này, lược đồ thanh ghi tái định cư được sử dụng để bảo vệ các tiến trình của người dùng với nhau và khỏi việc thay đổi mã và dữ liệu của hệ điều hành. Thanh ghi chuyển vị trí chứa giá trị của địa chỉ vật lý nhỏ nhất trong khi thanh ghi giới hạn chứa dải địa chỉ logic. Mỗi địa chỉ logic phải nhỏ hơn thanh ghi giới hạn. |
| 2 | Multiple-partition allocation | Trong kiểu phân bổ này, bộ nhớ chính được chia thành một số phân vùng có kích thước cố định trong đó mỗi phân vùng chỉ nên chứa một tiến trình. Khi một phân vùng trống, một tiến trình được chọn từ hàng đợi đầu vào và được tải vào phân vùng miễn phí. Khi quá trình kết thúc, phân vùng sẽ có sẵn cho một quá trình khác. |

## Fragmentation

Khi các tiến trình được tải và xóa khỏi bộ nhớ, không gian bộ nhớ trống bị chia thành nhiều phần nhỏ. Điều đó xảy ra sau khi đôi khi các tiến trình không thể được cấp phát cho các khối bộ nhớ vì kích thước nhỏ của chúng và các khối bộ nhớ vẫn chưa được sử dụng. Vấn đề này được gọi là Phân mảnh.

Phân mảnh có hai loại

| SN | Fragmentation  | Description |
| --- | --- | --- |
| 1 | External fragmentation | Tổng không gian bộ nhớ đủ để đáp ứng một yêu cầu hoặc để chứa một tiến trình trong đó, nhưng nó không liền kề, vì vậy nó không thể được sử dụng. |
| 2 | Internal fragmentation | Khối bộ nhớ được gán cho quá trình lớn hơn. Một số phần của bộ nhớ không được sử dụng vì nó không thể được sử dụng bởi một quá trình khác. |

Sơ đồ sau đây cho thấy cách phân mảnh có thể gây ra lãng phí bộ nhớ và một kỹ thuật nén có thể được sử dụng để tạo ra nhiều bộ nhớ trống hơn từ bộ nhớ bị phân mảnh.

![](../_src/images/memory-management/memory_fragmentation.jpg)

Tổng thời gian thực hiện bởi quá trình hoán đổi bao gồm thời gian cần thiết để di chuyển toàn bộ quá trình sang đĩa phụ và sau đó sao chép quá trình trở lại bộ nhớ, cũng như thời gian quá trình lấy lại bộ nhớ chính.

Chúng ta hãy giả sử rằng quy trình của người dùng có kích thước 2048KB và trên đĩa cứng tiêu chuẩn nơi quá trình hoán đổi sẽ diễn ra có tốc độ truyền dữ liệu khoảng 1 MB mỗi giây. Quá trình chuyển 1000K thực tế đến hoặc từ bộ nhớ sẽ mất.

...