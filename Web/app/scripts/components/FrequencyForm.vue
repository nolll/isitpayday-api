<template>
    <div>
        <h3>Frequency</h3>
        <div class="frequency-info">
            <p v-show="showForm">
                <select v-model.number="frequency">
                    <option v-for="f in frequencies" :value="f.id">{{f.name}}</option>
                </select>
                <a href="#" @click.prevent="close">Cancel</a>
            </p>
            <p v-show="!showForm">
                {{frequencyName}}
                <a href="#" @click.prevent="open">Change</a>
            </p>
        </div>
    </div>
</template>

<script>
    import frequencies from '../frequencies';

    export default {
        data: function () {
            return {
                showForm: false,
                frequencies: [
                    { id: frequencies.monthly, name: 'Monthly' },
                    { id: frequencies.weekly, name: 'Weekly' }
                ]
            };
        },
        computed: {
            frequency: {
                get() {
                    return this.$store.getters.frequency;
                },
                set(value) {
                    this.$store.dispatch('selectFrequency', value);
                    this.close();
                }
            },
            frequencyName: function () {
                var i;
                for (i = 0; i < this.frequencies.length; i++) {
                    var f = this.frequencies[i];
                    if (f.id === this.frequency) {
                        return f.name;
                    }
                }
                return "";
            }
        },
        methods: {
            open: function () {
                this.showForm = true;
            },
            close: function () {
                this.showForm = false;
            }
        }
    };
</script>
