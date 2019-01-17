import { NewPreview } from './new';
import { SpecialtyPreview } from './specialty';
import { Partner } from './partner';
import { Certificate } from './certificate'; 

export class MainPageModel {
    constructor(
        public news: NewPreview[],
        public specialties: SpecialtyPreview[],
        public partners: Partner[],
        public certificates: Certificate[]
    ){}
}