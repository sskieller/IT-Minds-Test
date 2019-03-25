package com.itminds.guessthepattern.c;

public abstract class Bar {
    protected  Foo foo;

    protected Bar(Foo foo) {
        this.foo = foo;
    }

    public abstract void update();
}
