# 1 Course Overview

- IP addressing and subnetting
- Ethernet Operation
- Ports and Protocols

# 2 Introduction To Networking

## What is Data Networking?

- Moving information from one device, to another device (di chuyển thông tin từ thiết bị này sang thiết bị khác)

## Understanding Data Networking

## Modeling Systems

- Message - Concept
- Englist - Language
- Vibration - Link
- Air - Physical

# 3 The OSI Model

## 3.1 What is OSI Model

Open Systems Interconnection model (mô hình kết nối hệ thống mở) là một mô hình khái niệm được tạo ra bởi Tổ chức Tiêu chuẩn hóa Quốc tế, cho phép các hệ thống truyền thông đa dạng giao tiếp bằng cách sử dụng các giao thức chuẩn. Bằng tiếng Anh đơn giản, OSI cung cấp một tiêu chuẩn cho các hệ thống máy tính khác nhau có thể giao tiếp với nhau.

Mô hình OSI có thể được coi là một ngôn ngữ chung cho mạng máy tính. Nó dựa trên khái niệm chia nhỏ hệ thống liên lạc thành bảy lớp trừu tượng, mỗi lớp xếp chồng lên nhau.

![osi-model-7-layers](./images/osi-model-7-layers.svg)

Mỗi lớp của Mô hình OSI xử lý một công việc cụ thể và giao tiếp với các lớp bên trên và bên dưới của chính nó. Các cuộc tấn công DDoS nhắm vào các lớp cụ thể của kết nối mạng; tấn công lớp ứng dụng mục tiêu lớp 7 và lớp giao thức tấn công nhắm mục tiêu lớp 3 và 4.

## 3.2 Why does the OSI model matter? (Tại sao mô hình OSI lại quan trọng?)

Mặc dù Internet hiện đại không tuân thủ nghiêm ngặt Mô hình OSI (nó tuân theo bộ giao thức Internet đơn giản hơn), nhưng Mô hình OSI vẫn rất hữu ích để khắc phục sự cố mạng. Cho dù đó là một người không thể đưa máy tính xách tay của họ lên Internet hoặc một trang web bị ngừng hoạt động đối với hàng nghìn người dùng, thì Mô hình OSI có thể giúp khắc phục sự cố và cô lập nguồn gốc của sự cố. Nếu vấn đề có thể được thu hẹp trong một lớp cụ thể của mô hình, thì có thể tránh được nhiều công việc không cần thiết.

## 3.2 Bảy lớp của Mô hình OSI là gì?

Bảy lớp trừu tượng của mô hình OSI có thể được định nghĩa như sau, từ trên xuống dưới:

### **Layer 7. The application layer**

![7-application-layer](./images//7-application-layer.svg)

Đây là lớp duy nhất tương tác trực tiếp với dữ liệu từ người dùng. Các ứng dụng phần mềm như trình duyệt web và ứng dụng email dựa vào lớp ứng dụng để bắt đầu giao tiếp. Nhưng cần làm rõ rằng các ứng dụng phần mềm máy khách không phải là một phần của lớp ứng dụng; thay vào đó, lớp ứng dụng chịu trách nhiệm về các giao thức và thao tác dữ liệu mà phần mềm dựa vào để trình bày dữ liệu có ý nghĩa cho người dùng. Giao thức lớp ứng dụng bao gồm HTTP cũng như SMTP (Giao thức truyền thư đơn giản là một trong những giao thức cho phép truyền thông qua email).

Các chức năng của lớp Ứng dụng là:  

- Network Virtual Terminal
- FTAM-File transfer access and management
- Mail Services
- Directory Services

> Mô hình OSI hoạt động như một mô hình tham chiếu và không được thực hiện trên Internet vì phát minh muộn. Mô hình hiện tại đang được sử dụng là mô hình TCP / IP.

### **Layer 6. The presentation layer (lớp trình bày)**

![6-presentation-layer](./images/6-presentation-layer.svg)

Lớp này chịu trách nhiệm chính trong việc chuẩn bị dữ liệu để nó có thể được sử dụng bởi lớp ứng dụng; nói cách khác, lớp 6 làm cho dữ liệu hiển thị cho các ứng dụng sử dụng. Lớp trình bày chịu trách nhiệm dịch, mã hóa và nén dữ liệu.

Hai thiết bị giao tiếp đang giao tiếp có thể sử dụng các phương pháp mã hóa khác nhau, do đó, lớp 6 chịu trách nhiệm dịch dữ liệu đến thành một cú pháp mà lớp ứng dụng của thiết bị nhận có thể hiểu được.

Nếu các thiết bị đang giao tiếp qua một kết nối được mã hóa, lớp 6 chịu trách nhiệm thêm mã hóa ở đầu người gửi cũng như giải mã mã hóa ở đầu người nhận để nó có thể hiển thị lớp ứng dụng với dữ liệu không được mã hóa, có thể đọc được.

Cuối cùng, lớp trình bày cũng chịu trách nhiệm nén dữ liệu mà nó nhận được từ lớp ứng dụng trước khi phân phối đến lớp 5. Điều này giúp cải thiện tốc độ và hiệu quả của giao tiếp bằng cách giảm thiểu lượng dữ liệu sẽ được truyền.

- Translation: For example, ASCII to EBCDIC.
- Encryption/ Decryption: Mã hóa dữ liệu chuyển dữ liệu sang dạng hoặc mã khác. Dữ liệu được mã hóa được gọi là bản mã và dữ liệu được giải mã được gọi là văn bản thuần túy. Giá trị khóa được sử dụng để mã hóa cũng như giải mã dữ liệu.
- Compression: Giảm số lượng bit cần truyền trên mạng.

### **Layer 5. The session layer (lớp session)**

![5-session-layer](./images/5-session-layer.svg)

Đây là lớp chịu trách nhiệm đóng mở giao tiếp giữa hai thiết bị. Khoảng thời gian từ khi giao tiếp được mở và đóng được gọi là phiên. Lớp phiên đảm bảo rằng phiên vẫn mở đủ lâu để chuyển tất cả dữ liệu đang được trao đổi, và sau đó nhanh chóng đóng phiên để tránh lãng phí tài nguyên.

Lớp phiên cũng đồng bộ hóa việc truyền dữ liệu với các điểm kiểm tra. Ví dụ: nếu một tệp 100 megabyte đang được chuyển, lớp phiên có thể đặt một điểm kiểm tra cứ sau 5 megabyte. Trong trường hợp ngắt kết nối hoặc sự cố sau khi 52 megabyte đã được chuyển, phiên có thể được tiếp tục từ điểm kiểm tra cuối cùng, nghĩa là chỉ cần chuyển thêm 50 megabyte dữ liệu. Nếu không có các trạm kiểm soát, toàn bộ quá trình chuyển sẽ phải bắt đầu lại từ đầu.

Các chức năng của lớp phiên là:  

- Thiết lập, duy trì và kết thúc phiên: Lớp cho phép hai quá trình thiết lập, sử dụng và chấm dứt kết nối.
- Đồng bộ hóa: Lớp này cho phép một quy trình thêm các điểm kiểm tra được coi là điểm đồng bộ hóa vào dữ liệu. Các điểm đồng bộ hóa này giúp xác định lỗi để dữ liệu được đồng bộ hóa lại đúng cách và các kết thúc của thông báo không bị cắt sớm và tránh mất mát dữ liệu.
- Bộ điều khiển hộp thoại: Lớp phiên cho phép hai hệ thống bắt đầu giao tiếp với nhau trong một nửa song công hoặc song công đầy đủ.

> Tất cả 3 lớp bên dưới (bao gồm cả Lớp phiên) được tích hợp thành một lớp duy nhất trong mô hình TCP / IP với tên gọi "Lớp ứng dụng". Việc triển khai 3 lớp này được thực hiện bởi chính ứng dụng mạng. Chúng còn được gọi là Lớp trên (Upper Layers) hoặc Lớp Phần mềm (Software Layers).

### **Layer 4. The transport layer (lớp vận chuyển)**

![4-transport-layer](./images/4-transport-layer.svg)

Lớp 4 chịu trách nhiệm giao tiếp đầu cuối giữa hai thiết bị. Điều này bao gồm việc lấy dữ liệu từ lớp phiên và chia nó thành các phần được gọi là phân đoạn trước khi gửi đến lớp 3. Lớp truyền tải trên thiết bị nhận có trách nhiệm tập hợp lại các phân đoạn thành dữ liệu mà lớp phiên có thể sử dụng.

Tầng vận chuyển cũng chịu trách nhiệm kiểm soát luồng và kiểm soát lỗi. Kiểm soát luồng xác định tốc độ truyền tối ưu để đảm bảo rằng người gửi có kết nối nhanh không lấn át người nhận có kết nối chậm. Lớp truyền tải thực hiện kiểm soát lỗi ở đầu nhận bằng cách đảm bảo rằng dữ liệu nhận được là hoàn chỉnh và yêu cầu truyền lại nếu không.

> Dữ liệu trong Lớp truyền tải được gọi là Phân đoạn (Segments).

> Lớp vận chuyển được vận hành bởi Hệ điều hành. Nó là một phần của Hệ điều hành và giao tiếp với Lớp ứng dụng bằng cách thực hiện các lệnh gọi hệ thống.

> Tầng vận chuyển được gọi là Trái tim của mô hình OSI .

### **Layer 3. The network layer (lớp mạng)**

![3-network-layer](./images/3-network-layer.svg)

Lớp mạng có nhiệm vụ tạo điều kiện thuận lợi cho việc truyền dữ liệu giữa hai mạng khác nhau. Nếu hai thiết bị giao tiếp trên cùng một mạng, thì lớp mạng là không cần thiết. Lớp mạng chia nhỏ các phân đoạn từ lớp truyền tải thành các đơn vị nhỏ hơn, được gọi là gói, trên thiết bị của người gửi và tập hợp lại các gói này trên thiết bị nhận. Lớp mạng cũng tìm ra con đường vật lý tốt nhất để dữ liệu đến đích của nó; điều này được gọi là định tuyến.

> Segment trong lớp Mạng được gọi là Packet.

### **Layer 2. The Data Link Layer (lớp liên kết dữ liệu)**

![2-data-link-layer](./images/2-data-link-layer.svg)

Lớp liên kết dữ liệu rất giống với lớp mạng, ngoại trừ lớp liên kết dữ liệu tạo điều kiện truyền dữ liệu giữa hai thiết bị trên cùng một mạng. Lớp liên kết dữ liệu lấy các gói từ lớp mạng và chia chúng thành các phần nhỏ hơn gọi là khung. Giống như lớp mạng, lớp liên kết dữ liệu cũng chịu trách nhiệm kiểm soát luồng và kiểm soát lỗi trong giao tiếp nội bộ (lớp vận chuyển chỉ kiểm soát luồng và kiểm soát lỗi đối với giao tiếp giữa mạng).

> Packet rong lớp lớp liên kết dữ liệu được gọi là Frame.

> Lớp Liên kết dữ liệu được xử lý bởi NIC (Network Interface Card) và trình điều khiển thiết bị của các máy chủ.

### **Layer 1. The physical layer (lớp vật lý)**

![1-physical-layer](./images/1-physical-layer.svg)

Lớp này bao gồm các thiết bị vật lý liên quan đến việc truyền dữ liệu, chẳng hạn như cáp và thiết bị chuyển mạch. Đây cũng là lớp nơi dữ liệu được chuyển đổi thành một luồng bit, là một chuỗi gồm các số 1 và 0. Lớp vật lý của cả hai thiết bị cũng phải đồng ý về một quy ước tín hiệu để các số 1 có thể được phân biệt với các số 0 trên cả hai thiết bị.

## 3.3 How data flows through the OSI Model

Để thông tin có thể đọc được của con người được chuyển qua mạng từ thiết bị này sang thiết bị khác, dữ liệu phải đi xuống bảy lớp của Mô hình OSI trên thiết bị gửi và sau đó di chuyển lên bảy lớp ở đầu nhận.

Ví dụ: Ông Cooper muốn gửi cho bà Palmer một email. Ông Cooper soạn tin nhắn của mình trong một ứng dụng email trên máy tính xách tay của mình và sau đó nhấn 'gửi'. Ứng dụng email của anh ấy sẽ chuyển email của anh ấy sang lớp ứng dụng, sẽ chọn một giao thức (SMTP) và chuyển dữ liệu đến lớp trình bày. Lớp trình bày sau đó sẽ nén dữ liệu và sau đó nó sẽ nhấn lớp phiên, sẽ khởi tạo phiên giao tiếp.

Dữ liệu sau đó sẽ nhấn vào lớp vận chuyển của người gửi, nơi nó sẽ được phân đoạn, sau đó các phân đoạn đó sẽ được chia thành các gói ở lớp mạng, sẽ được chia nhỏ hơn nữa thành các khung ở lớp liên kết dữ liệu. Lớp liên kết dữ liệu sau đó sẽ cung cấp các khung đó đến lớp vật lý, sẽ chuyển đổi dữ liệu thành một dòng điện từ 1 và 0 và gửi nó qua một phương tiện vật lý, chẳng hạn như cáp.

Khi máy tính của cô Palmer nhận được luồng bit thông qua một phương tiện vật lý (như wifi của cô), dữ liệu sẽ chảy qua cùng một loạt các lớp trên thiết bị của cô, nhưng theo thứ tự ngược lại. Đầu tiên, lớp vật lý sẽ chuyển đổi BITSTREAM từ 1 và 0 thành các khung được chuyển sang lớp liên kết dữ liệu. Lớp liên kết dữ liệu sau đó sẽ lắp lại các khung vào các gói cho lớp mạng. Lớp mạng sau đó sẽ tạo các phân đoạn ra khỏi các gói cho lớp vận chuyển, điều này sẽ sắp xếp lại các phân đoạn thành một phần dữ liệu.

Dữ liệu sau đó sẽ chảy vào lớp phiên của người nhận, sẽ truyền dữ liệu theo lớp trình bày và sau đó kết thúc phiên giao tiếp. Lớp trình bày sau đó sẽ loại bỏ nén và chuyển dữ liệu thô lên lớp ứng dụng. Lớp ứng dụng sau đó sẽ cung cấp dữ liệu có thể đọc được của con người cho phần mềm email của cô Palmer, điều này sẽ cho phép cô đọc email của ông Cooper trên màn hình máy tính xách tay của mình.

# 4 Protocols and Port Numbers

- Application Layer Protocols
  - Data Transfer Protocol (DTP)
  - Authentication Protocol (AP)
  - Network Services Protocol (NSP)
  - Network Management Protocol (NMP)
  - Audio/Visual Protocol (AV)

## 4.1 Transferring Data: HTTP or HTTPS

Hypertext Transfer Protocol (secure)

| Layer | | |
| --- | --- | --- |
| Application Layer (7) | HTTP | HTTPs |
| Transport Layer (4) | 80 | 443 |

## 4.2 File Transfer: FTP, sFTP, TFTP and SMB

| Layer | | | | |
| --- | --- | --- | --- | --- |
| Application Layer (7) | FTP | sFTP | TFTP | SMB |
| Transport Layer (4) | 20 21 | 22 | 69 | 445 |

TFTP: tiny FTP, truyền tệp nhỏ, nên dùng trong trường hợp cần truyền file nhỏ như file conf vì nó k cần phải lo về bảo mật và tường lửu (k yêu cầu username và passwd)
