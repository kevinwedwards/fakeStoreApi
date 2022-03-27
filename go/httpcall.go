package main

import (
    "encoding/json"
    "io/ioutil"
    "log"
    "fmt"
    "net/http"
    "sort"
 )


 type Product struct {
        ID          int     `json:"id"`
        Title       string  `json:"title"`
        Price       float64 `json:"price"`
        Description string  `json:"description"`
        Category    string  `json:"category"`
        Image       string  `json:"image"`
        Rating      Rating 
}

type Rating struct {
    Rate  float64 `json:"rate"`
    Count int     `json:"count"`
}
func main() {

    resp, err := http.Get("http://fakestoreapi.com/products")
    if err != nil {
       log.Fatalln(err)
    }
    
    body, err := ioutil.ReadAll(resp.Body)
    if err != nil {
       log.Fatalln(err)
    }

    //Convert the body to type string
    productsJson := string(body)
    // log.Printf(sb)


    var products []Product
    json.Unmarshal([]byte(productsJson), &products)
 //   fmt.Printf("Products : %+v", products)

    highlyratedProducts := []Product{}


    for i := range products {
        if products[i].Rating.Rate > 3.8 {
            highlyratedProducts = append(highlyratedProducts, products[i])
        }
    }

    sort.SliceStable(highlyratedProducts, func(i, j int) bool {
        return highlyratedProducts[i].Rating.Rate > highlyratedProducts[j].Rating.Rate
    })
   
    for i := range highlyratedProducts {
        fmt.Printf("(%.1f) - %s \n", highlyratedProducts[i].Rating.Rate, highlyratedProducts[i].Title)
    }

}
