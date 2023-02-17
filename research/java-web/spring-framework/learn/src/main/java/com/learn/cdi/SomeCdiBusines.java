package com.learn.cdi;

import javax.inject.Inject;
import javax.inject.Named;

@Named
public class SomeCdiBusines {
    @Inject
    SomeCdiDAO someCdiDAO;

    public SomeCdiDAO getCdidao() {
        return this.someCdiDAO;
    }

    public void setSomeCdiDAO(SomeCdiDAO someCdiDAO) {
        this.someCdiDAO = someCdiDAO;
    }

}
