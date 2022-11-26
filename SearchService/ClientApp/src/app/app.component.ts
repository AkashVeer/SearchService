import { Component, OnInit } from '@angular/core';
import { ApiserviceService } from './apiservice.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'ClientApp';
  searchInput: string = "";
	searchResult: any = [];

  constructor(private apiService:ApiserviceService){}
  ngOnInit() {

  }

  search() {
    this.apiService.Search(this.searchInput).subscribe(response => {
      this.searchResult = response;
    }, error => {
      alert('Something went wrong!!');
    })
  }

  getProperties(obj:any){
    return Object.keys(obj).map((key)=>{ return key});
  }
}
