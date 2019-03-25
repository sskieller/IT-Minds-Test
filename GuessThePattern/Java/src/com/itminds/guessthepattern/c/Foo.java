package com.itminds.guessthepattern.c;

import java.util.ArrayList;
import java.util.List;

public abstract class Foo {
    private List<Bar> list = new ArrayList<>();

    public void attach(Bar bar) {
        list.add(bar);
    }

    public void detach(Bar bar) {
        list.remove(bar);
    }

    public void signal() {
        for (Bar o : list){
            o.update();
        }
    }
}

/* Write your answers and comments below this line

*/
