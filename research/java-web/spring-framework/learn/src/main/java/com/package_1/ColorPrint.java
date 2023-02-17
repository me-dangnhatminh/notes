package com.package_1;

import org.springframework.stereotype.Component;

@Component
public class ColorPrint {
    public void red(String content) {
        System.out.println("\u001B[31m" + content + "\u001B[0m");
    }

}
