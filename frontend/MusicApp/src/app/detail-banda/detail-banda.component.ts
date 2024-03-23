import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Route } from '@angular/router';
import { Banda } from '../model/banda';
import { BandaService } from '../services/banda.service';
import { Album } from '../model/album';
import {MatExpansionModule} from '@angular/material/expansion';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-detail-banda',
  standalone: true,
  imports: [MatExpansionModule, CommonModule],
  templateUrl: './detail-banda.component.html',
  styleUrl: './detail-banda.component.css'
})
export class DetailBandaComponent implements OnInit {

  idBanda = '';
  banda!:Banda;
  albuns!:Album[];

  constructor(private route: ActivatedRoute, private bandaService: BandaService) {  }
  
  ngOnInit(): void {
    this.idBanda = this.route.snapshot.params["id"];

    this.bandaService.getBandaPorId(this.idBanda).subscribe(response => {
      this.banda = response;
    });

    this.bandaService.getAlbunsBanda(this.idBanda).subscribe(response => {
      this.albuns = response;
      console.log(this.albuns);
    });

  }

}
