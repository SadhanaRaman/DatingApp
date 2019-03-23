import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {
  
  values: any; // Similar to Var in Javascript
  
  // Inject the HttpClient service we imported in our app.module to our constructor
  constructor(private http:HttpClient) { }


  // Happens after constructor is initialized
  ngOnInit() {
  this.getValues();
  }

  // This method has subscribed to the observable stream of data from the server
  getValues(){
    this.http.get('http://localhost:5000/api/values').subscribe(response => {this.values = response;} 
    ,error => {console.log(error);});   
  }
}
