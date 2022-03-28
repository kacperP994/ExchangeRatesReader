import { Component, OnInit } from '@angular/core';
import { LoadMaskService } from '../services/load-mask.service';

/**
 * Component responsible for showing a loading spinner during backend api requests
 */
@Component({
  selector: 'app-load-mask',
  templateUrl: './load-mask.component.html',
  styleUrls: ['./load-mask.component.less']
})
export class LoadMaskComponent implements OnInit {

  constructor(public loadMaskService: LoadMaskService) { }

  ngOnInit(): void {
    
  }

}
