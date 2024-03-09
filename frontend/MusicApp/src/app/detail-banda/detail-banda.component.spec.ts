import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailBandaComponent } from './detail-banda.component';

describe('DetailBandaComponent', () => {
  let component: DetailBandaComponent;
  let fixture: ComponentFixture<DetailBandaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DetailBandaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DetailBandaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
