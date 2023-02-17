package com.learn;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import com.constants.COLOR_PRINTLN;

public class LearnApplicationContextApplication {
	private static Logger LOGGER = LoggerFactory.getLogger(LearnApplicationContextApplication.class);

	public static void main(String[] args) {

		try (ClassPathXmlApplicationContext applicationContext = new ClassPathXmlApplicationContext(
				"applicationContext.xml")) {

		} catch (Exception e) {
			LOGGER.error(COLOR_PRINTLN.RED + "{}" + COLOR_PRINTLN.RESET, e.getMessage());
		}
	}
}
