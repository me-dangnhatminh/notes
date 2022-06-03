# Chapter 1. Concurrency: An Overview
## Introduction to concurrency
    - Concurrency: Làm nhiều việc cùng một lúc.
    - Multithreading: Một dạng đồng thời sử dụng nhiều luồng thực thi.
    - Parallel processing: Thực hiện nhiều công việc bằng cách chia nó thành nhiều luồng chạy đồng thời.
    -> Parallel processing là một kiểu Multithreading và MT là một kiểu Concurrency.
    - Có một kiểu concurrency khác là Asynchronous programming.
    - Reactive programming: là một kiểu concurrency khác, Một kiểu lập trình khai báo trong đó ứng dụng phản ứng với các sự kiện.
### Asynchronous Programming

**⚠ WARNING:** tránh sử dụng async void, chỉ nên làm như thế khi muốn viết một async trình xử lý sự kiện (event hanlder). Một async phương thức thông thường không có giá trị sẽ trả về **Task**