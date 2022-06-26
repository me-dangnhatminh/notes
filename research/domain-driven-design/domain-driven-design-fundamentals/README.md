# 2 Intrucing Domain-Driven Design

## 2.3 Understaning the Value of Domain-Driven Design

> Domain-Driven Design is an approach to software devlopment that centers the development on programming a domain model that has a richunderstanding of the processes and rules of a domain.
> </br>**Martin Fowler**

Value Proposition of DDD (Đề xuất giá trị của DDD)

- Principles & patterns to **solve difficult problems** (Các nguyên tắc và mô hình để giải quyết các vấn đề khó khăn)
- History of **success with complex projects**
- Aligns with practices from our own experience
- Clear, readable, testable code that pepresents the domain

![solve problems](./assets/images/solve-problems.png)

Tackling complexity in the heart of software (Giải quyết sự phức tạp trong trung tâm của phần mềm)

## 2.4 Exploring the Benefits and Potential Drawbacks of DDD

#### Benefits of Domain-Driven Design

- Flexible (Linh hoạt)
- Customer's vison/perspective of the problem (Tầm nhìn / quan điểm của khách hàng về vấn đề)
- Path through a very complex problem (Con đường vượt qua một vấn đề rất phức tạp)
- Well-organized and easily tested code (Mã được tổ chức tốt và dễ dàng kiểm tra)
- Business logic lives in one place (Logic kinh doanh đều tồn tại ở một nơi)
- Many great patterns to leverage (Nhiều mô hình tuyệt vời để tận dụng)

#### Be Prepared for Time and Effort

- Discuss and model the problem with domain experts (Thảo luận và lập mô hình vấn đề với các chuyên gia miền)
- Isolate domain logic from other parts of application (Cách ly logic miền khỏi các phần khác của ứng dụng)

#### Inspecting a Mind Map of Domain-Driven Design

![DomainDrivenDesignReference](./assets/images/DomainDrivenDesignReference.png)

## 2.5 Introduction Our Sample Application

## 2.6 Exploring the sample app's high-level structure

DEMO: <https://github.com/ardalis/pluralsight-ddd-fundamentals.git>

# 3 Modeling Problems in Software

## 3.1 Overview

- Breaking up the veterinary office domain
- The importtance of the domain experts
- A play! (Discovering the domain)
- Core elements of a domain model
- Subdomains and bounded contexts (Tên miền phụ và các ngữ cảnh bị ràng buộc)
- That ubiquitous tern: ubiquitous languages (Đó là ngôn ngữ phổ biến: ngôn ngữ phổ biến)

## 3.2 Introduction Our Domain

- Our domain: A Veterinary Practice (Thực hành thú y)
- More than just caring for pets
  - Schedule: lập lịch
  - Invoices: hóa đơn
  - Payment: thanh toán
  - Records: lưu trữ và truy xuất hồ sơ y tế
  - External Resources: thí nghiệm bên ngoài

## 3.3 Planning Ahead to Learn About the Domain (Lập kế hoạch trước khi tìm hiểu ...)

### Our goals for learning about the domain (Mục tiêu của chúng tôi là tìm hiểu về miền)

- Understand client's business
- Identify processes beyond project scope (Xác định các quy trình ngoài phạm vi dự án)
- Look for subdomain we should include (Tìm tên miền phụ mà chúng ta nên đưa vào)
- Look for subdomain we can ignore (Tìm tên miền phụ mà chúng ta có thể bỏ qua)

## 3.4 Conversation with a Domain Expert: Exploring the Domain and Its Subdomains

Trò chuyện với chuyên gia miền: Khám phá miền và các miền phụ của miền đó

### Learning about the Complete Domain (Tìm hiều về miền hoàn chỉnh)

- Patient scheduling (Lên lịch cho bệnh nhân)
- Owner and pet data management (Quản lý dữ liệu chủ và vật nuôi)
- Surgery scheduling (Lên lịch phẫu thuật)
- Office visit data collection (Thu thập dữ liệu chuyến thăm văn phòng)
- Billing (External?)
- Sales and Inventory (Bán hàng và hàng tồn kho)
- Lab testing (Schedule, results, bill)
- Prescription (Đơn thuốc)
- Staff scheduling (Nhân viên lên lịch)
- CMS (Content Management System: Hệ thống quản lý nội dung)

### So Many Problems to Solve (Rất nhiều vấn đề cần giải quyết)

### -> Some of the Identified Subdomains

- Staff (Nhân viên)
- Accounting (Kế toán)
- Client and patient records (Hồ sơ khách hàng và bệnh nhân)
- Visit records (Truy cập hồ sơ)
- Appointments Scheduleing (Lên lịch cuộc hẹn)
- Sales (Việc bán hàng)

## 3.5 Conversation with a Domain Expert: Exploring the Scheduling Subdomain

Trò chuyện với chuyên gia miền: Khám phá miền phụ lập lịch
