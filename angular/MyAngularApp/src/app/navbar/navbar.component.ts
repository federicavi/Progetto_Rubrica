
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { INavbarItems } from '../Interfacce/interface';
import { HomeService } from '../Service/homeService';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
})
export class NavbarComponent implements OnInit {

  navbarItems : INavbarItems[] = [];
  
  constructor(private readonly homeService : HomeService){}

  ngOnInit(): void {
    this.homeService.getNavbarItems().subscribe(items=>{
      this.navbarItems = items;
      });
  }
}
