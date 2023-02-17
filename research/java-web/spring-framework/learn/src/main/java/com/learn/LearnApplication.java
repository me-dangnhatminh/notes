package com.learn;

import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;

import com.package_1.ColorPrint;

@ComponentScan("com")
@Configuration
public class LearnApplication {
	public static void main(String[] args) {
		try (AnnotationConfigApplicationContext applicationContext = new AnnotationConfigApplicationContext(
				LearnApplication.class)) {
			ColorPrint colorPrint = applicationContext.getBean(ColorPrint.class);
			colorPrint.red("--------------------------------------------------------------------");
		} catch (Exception e) {
			// TODO: handle exception
		}
	}

}
