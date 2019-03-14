import { NewPreview } from './new';
import { SpecialtyPreviewModel } from './specialty';
import { Partner } from './partner';
import { Certificate } from './certificate'; 

export class MainPageModel {
    constructor(
        public news: NewPreview[],
        public specialties: SpecialtyPreviewModel[],
        public partners: Partner[],
        public certificates: Certificate[]
    ){}
}