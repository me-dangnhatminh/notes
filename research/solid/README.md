# SOLID

# 1 The Single Responsibility Principle

Trách nhiệm duy nhất

## 1.2 Definition

Theo wikipedia, Trách nhiệm đơn lẻ là mọi đối tượng phải có trách nhiệm duy nhất và trách nhiệm đó phải được đóng gói hoàn toàn bởi class. Nghĩa là không bao giờ có nhiều hơn một lý do cho một class thay đổi

### Cohesion and coupling (Sự liên kết và khớp nối)

- Cohesion: Các trách nhiệm khác nhau của một module có liên quan mạnh mẽ và tập trung như thế nào?
- Coupling: Mức độ mà mỗi module chương trình hoặc class phụ thuộc vào mỗi một trong các mô-đun khác.
- Phấn đấu để **low coupling** và **high cohesion**

## 1.3 Responsibilites are Axes of Change

- Các yêu cầu thay đổi thường liên quan đến trách nhiệm
