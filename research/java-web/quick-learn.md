# Angenda

- java intro
- java file compilation
- what is a JDK?
- JDK download
- what is an IDE
- IDE download
- project setup
- classes
- main method
- println()
- escape sequences
- comments
- tips and tricks

## I. Java intro

Why you need to learn:

1. Top 3 most popular languages
2. Extremely flexible
3. Easy to find a job as a developer

## II. Java file compilation

- Source code for human (compiler to) --> byte code (JVM to) --> machine code for computer

## III. JDK

- JDK (Java Development Kit): chứa các công cụ phát triển

  - JRE (Java Runtime Env): các thư viện và toolkits

    - JVM (Java Virtual Machine): chạy chương trình java

## Variables in java

| Primitive | Reference |
| --- | --- |
| 8 byte | k giới hạn |
| lưu trữ data | lưu trữ địa chỉ |
| chỉ dữ được 1 giá trị | có thể chứa nhiều hơn 1 giá trị |
| ít bộ nhớ | nhiều bộ nhớ |
| nhanh | chậm |

## Nhập xuất dữ liệu

``` java
// cach 1
Scanner scanner = new Scanner(System.in);
String name = scanner.nextLine();
// cach 2
 String name = JOptionPane.showInputDialog("Your name");
 JOptionPane.showMessageDialog(null, "Your name");
```

## Basic Tools and Frameworks

Giới thiệu Mocking với Mockito

- Testing tốt và dễ dàng bảo trì

- Để viết testing tốt trong ứng dụng nhiều lớp

  - Opt 1: Stubs
  - Opt 2: Mocks
