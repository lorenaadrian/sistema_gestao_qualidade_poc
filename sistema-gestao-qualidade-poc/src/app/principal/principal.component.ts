import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-principal',
  templateUrl: './principal.component.html',
  styleUrls: ['./principal.component.css']
})
export class PrincipalComponent implements OnInit {
  urlImg: string = "./../../assets/SGQ_LOGO1.png";
  userName: string = sessionStorage.getItem('userName');
  constructor() { }

  ngOnInit(): void {
  }

}
