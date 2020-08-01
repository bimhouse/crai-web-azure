import { Component, OnInit } from '@angular/core';
import { CraiWorkService } from '../services/crai-work.service';
import { Portfolio } from './Portfolio';

@Component({
  selector: 'app-crai-work',
  templateUrl: './crai-work.component.html',
  styleUrls: ['./crai-work.component.css']
})
export class CraiWorkComponent implements OnInit {

  portfolio: Portfolio;

  constructor(private workService: CraiWorkService) { }

  ngOnInit() {
    this.workService.getData().subscribe(result => {
      console.log(result);
      this.portfolio = result;
      //this.portfolio = result.filter(x => x.active = true);
    });
  }

}
