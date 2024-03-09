import { TestBed } from '@angular/core/testing';

import { BandaService } from './banda.service';

describe('BandaService', () => {
  let service: BandaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BandaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
