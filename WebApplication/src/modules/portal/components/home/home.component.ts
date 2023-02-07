import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  uan: string;

  constructor(private router: Router) { }

  submitForm() {
    this.router.navigate(['search/student'], { queryParams: { 'uan': this.uan } });
  }
}