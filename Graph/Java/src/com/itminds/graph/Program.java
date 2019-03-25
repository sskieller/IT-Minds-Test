package com.itminds.graph;

public class Program {
    public static void main(String[] args) {
        CustomerNode curr = CustomerNode
                .Create("Kim")
                .previous("Hans")
                .previous("Ole")
                .previous("Peter");

        while (curr != null) {
            System.out.println(curr.getPerson());
            curr = curr.getNext();
        }
    }
}
