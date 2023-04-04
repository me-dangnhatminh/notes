package com.mokitodemo;

import static org.junit.jupiter.api.Assertions.fail;

import org.junit.jupiter.api.Test;
import org.springframework.boot.test.context.SpringBootTest;

@SpringBootTest
class MokitoDemoApplicationTests {

	@Test
	void case_1() {
		int number = 2;
		if (number == 1)
			fail("Test Fail");

		System.out.println("Test success");
	}

	@Test
	void case_2() {
	}

}
