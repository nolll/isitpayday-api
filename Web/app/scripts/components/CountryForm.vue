<template>
    <div>
        <h3>Country</h3>
        <div class="country-info">
            <p v-show="showForm">
                <select v-model="countryId">
                    <option v-for="c in countries" :value="c.id" :key="c.id">{{c.name}}</option>
                </select>
                <a href="#" @click.prevent="close">Cancel</a>
            </p>
            <p v-show="!showForm">
                <span v-text="countryName"></span>
                <a href="#" @click.prevent="open">Change</a>
            </p>
        </div>
    </div>
</template>

<script lang="ts">
    import { Country } from '@/types/Country';
    import { Component, Mixins, Prop } from 'vue-property-decorator';
    import { StoreMixin} from '../StoreMixin';
    
    @Component
    export default class CountryForm extends Mixins(
        StoreMixin
    ) {
        @Prop() readonly countries!: Country[];
        showForm = false;

        get countryName() {
            var i;
            for (i = 0; i < this.countries.length; i++) {
                const c = this.countries[i];
                if (c.id === this.countryId) {
                    return c.name;
                }
            }
            return '';
        }

        get countryId() {
            return this.$_countryId;
        }
        
        set countryId(value) {
            this.$_selectCountry(value);
            this.close();
        }

        open() {
            this.showForm = true;
        }

        close() {
            this.showForm = false;
        }
    }
</script>