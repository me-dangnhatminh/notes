package com.learn;

import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.PropertySource;

import com.learn.properties.SomeExternalService;
import com.package_1.ColorPrint;

@Configuration
@ComponentScan
@PropertySource("classpath:app.properties")
public class LearnApplicationPropertiesApplication {
    public static void main(String[] args) {
        try (AnnotationConfigApplicationContext applicationContext = new AnnotationConfigApplicationContext(
                LearnApplication.class)) {
            ColorPrint colorPrint = applicationContext.getBean(ColorPrint.class);
            colorPrint.red("--------------------------------------------------------------------");

            SomeExternalService someExternalService = applicationContext.getBean(SomeExternalService.class);
            colorPrint.red(someExternalService.returnServiceURL());
        } catch (Exception e) {
            // TODO: handle exception
        }
    }
}
