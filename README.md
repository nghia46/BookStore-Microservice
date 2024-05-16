Giải Thích Luồng Đi
Hệ thống quản lý sách sử dụng kiến trúc microservices và RabbitMQ để truyền thông điệp giữa các dịch vụ. Dưới đây là luồng đi chi tiết của hệ thống:

1. Tạo Người Dùng Mới
Người dùng gửi yêu cầu đăng ký qua API của UserService.
Endpoint: POST /users
UserService lưu thông tin người dùng vào cơ sở dữ liệu và trả về thông tin người dùng đã tạo.
2. Thêm Sách Mới
Quản trị viên gửi yêu cầu thêm sách mới qua API của BookService.
Endpoint: POST /books
BookService lưu thông tin sách vào cơ sở dữ liệu và trả về thông tin sách đã thêm.
3. Tạo Đơn Mượn Sách
Người dùng gửi yêu cầu mượn sách qua API của BorrowingService.
Endpoint: POST /borrowings
BorrowingService lưu thông tin đơn mượn sách vào cơ sở dữ liệu với trạng thái "Pending".
BorrowingService tạo và gửi thông điệp BorrowingRequestCreatedMessage qua RabbitMQ.
Exchange: borrowings
Routing Key: borrowing.created
4. Xử Lý Thông Điệp Từ RabbitMQ
NotificationService lắng nghe thông điệp borrowing.created từ RabbitMQ.
NotificationService tạo và gửi thông báo cho người dùng.
Endpoint: POST /notifications
Tổng Kết
Người dùng đăng ký tài khoản và quản trị viên thêm sách mới vào hệ thống.
Người dùng tạo đơn mượn sách qua BorrowingService, đơn mượn được lưu trữ và thông điệp về đơn mượn được gửi qua RabbitMQ.
NotificationService lắng nghe thông điệp từ RabbitMQ, xử lý thông điệp và gửi thông báo cho người dùng.
Luồng đi này đảm bảo rằng tất cả các thành phần của hệ thống hoạt động độc lập và giao tiếp hiệu quả thông qua RabbitMQ, tạo điều kiện cho việc mở rộng và bảo trì dễ dàng.
