# Session 2: Spring FW in Depth

AGENDA

- Autowiring Typesand Qualifiers
- Bean Scope and Life Cycle
- IOC Container and Application Context
- XML and Java Application Contexts
- Component Scan
- External Properties
- Container and Dependency Injection (CDI)

## step14 - Bean Scope

Default is Singleton

- singleton: một instance cho mỗi bối cảnh Spring
- prototype: bean mới bất cứ khi nào được yêu cầu
- request: 1 bean cho mỗi http request
- session: 1 bean cho mỗi http session

```java
import org.springframework.beans.factory.config.ConfigurableBeanFactory;

@Component
@Scope(ConfigurableBeanFactory.SCOPE_PROTOTYPE)
public class BinarySearchImpl {
}
```

## step17 - Lifecycle of a Bean

## step18 - Context and Dependency Injection (CDI)

Là một framework injection dependency tiêu chuẩn có trong java es6 trở lên, nó cho phép chúng tôi quản lý vòng đời của các thành phần trạng thái thông qua các ngữ cảnh vòng đời.

Spring hỗ trợ hầu hết các annotations

- @Inject (@Autowired)
- @Named (@Component & @Quantity)
- @Singleton (Defines a scope of Singleton)

## step21 - Xác định bối cảnh ứng dụng spring bằng XML

```java
package com.learn;

import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import com.package_1.ColorPrint;

@ComponentScan("com")
@Configuration
public class LearnApplication {
 public static void main(String[] args) {
  try (ClassPathXmlApplicationContext applicationContext = new ClassPathXmlApplicationContext("")) {
   ColorPrint colorPrint = applicationContext.getBean(ColorPrint.class);
   colorPrint.red("--------------------------------------------------------------------");
  } catch (Exception e) {
   // TODO: handle exception
  }
 }
}

```

## step23

## step24 - IOC container vs application context vs bean factory

Định lượng

- IOC Container
- Application Context
- Bean Factory

Application Context

- Bean Factory++
  - Spring's AOP features
  - I18n capabilities
  - WebApplicationContext for web applications etc

## step25 - Component , Service , Repository, Controller

Component Annotations

- @Component - thành phần chung
- @Repository - đóng gói hành vi lưu trữ, truy xuất và tìm kiểm điển hình từ cơ sở dữ liệu quan hệ
- @Service - business service facade
- @Controller - controller trong MVC pattern
